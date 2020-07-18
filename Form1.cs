using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTimer {
    public partial class Form1 : Form {
        private TimerManager timeManager;
        private TimeSpan inputTimeSpan;
        private String inputText;
        private bool isInputValid;
        public delegate void NotificationDelegate(string message);
        public event NotificationDelegate sysbusyEvent;
        public delegate void DataTableUpdateDelegate(List<Alarm> alarms);
        public event DataTableUpdateDelegate dataTableUpdate;

        public Form1() {
            InitializeComponent();
            timeInputTextbox.Text = "输入时间和内容";
            timeInputTextbox.SelectAll();
            timeInputTextbox.TextAlign = HorizontalAlignment.Center;
            timeInputTextbox.KeyUp += timeInputRichTextbox_Keyup;
            sysbusyEvent = delegate (string message) {
                notifyIcon1.ShowBalloonTip(1000, "到时间了", message, ToolTipIcon.None);
            };
            dataTableUpdate += delegate (List<Alarm> alarms) {
                updateDataTable(alarms);
            };
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            timeManager = new TimerManager(timer1, sysbusyEvent, dataTableUpdate);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 3) {
                timeManager.startStopReset(e.RowIndex);
            } else if (e.ColumnIndex == 4) {
                timeManager.removeAlarm(e.RowIndex);
            }
        }

        private void updateDataTable(List<Alarm> alarms) {
            // 行数变化
            if (alarms.Count > dataGridView1.Rows.Count) {
                int length = alarms.Count - dataGridView1.Rows.Count;
                dataGridView1.Rows.Add(length);
            } else if (alarms.Count < dataGridView1.Rows.Count) {
                for (int i = alarms.Count; i < dataGridView1.Rows.Count; i++) {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
            // 更新数据
            for (int i = 0; i < alarms.Count; i++) {
                var row = dataGridView1.Rows[i];
                Alarm alarm = alarms[i];
                row.Cells[0].Value = alarm.time.ToString();
                row.Cells[1].Value = alarm.message;
                row.Cells[2].Value = Alarm.getStateDescription(alarm.state);
                if (alarm.state == Alarm.RUNNING) {
                    row.Cells[3].Value = "停止";
                } else if (alarm.state == Alarm.STOPPED) {
                    row.Cells[3].Value = "开始";
                } else if (alarm.state == Alarm.DUE) {
                    row.Cells[3].Value = "重置";
                }
                row.Cells[4].Value = "删除";
                var rowStyle = row.DefaultCellStyle;
                if (alarm.state == Alarm.RUNNING) {
                    rowStyle.BackColor = Color.LightGreen;
                } else if (alarm.state == Alarm.DUE) {
                    rowStyle.BackColor = Color.LightPink;
                } else {
                    rowStyle.BackColor = Color.LightGray;
                }
                row.DefaultCellStyle = rowStyle;
            }
        }

        internal static string getTimeSpanDescription(TimeSpan timeSpan) {
            string result = "";
            if (timeSpan.Days != 0) {
                result += timeSpan.Days + "天";
            }
            if ((timeSpan.Hours != 0 || result.Length > 0) && (timeSpan.Hours != 0 || timeSpan.Minutes != 0 || timeSpan.Seconds != 0)) {
                result += timeSpan.Hours + "小时";
            }
            if ((result.Length > 0 || timeSpan.Minutes != 0) && (timeSpan.Minutes != 0 || timeSpan.Seconds != 0)) {
                result += timeSpan.Minutes + "分钟";
            }
            if (timeSpan.Seconds != 0) {
                result += timeSpan.Seconds + "秒";
            }
            if (result.Length == 0) {
                result = "0秒";
            }
            return result;
        }

        private void timeInputRichTextbox_Keyup(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (isInputValid) {
                    timeManager.addAlarm(inputTimeSpan, inputText);
                    timeInputTextbox.Text = "输入时间和内容";
                    timeInputTextbox.SelectAll();
                } else {
                    MessageBox.Show("输入无效");
                }
            }
        }

        private void timeInputRichTextbox_TextChanged(object sender, EventArgs e) {
            string timeText = timeInputTextbox.Text;
            int length = timeText.Length;
            int numberEnd = length;
            for (int i = 0; i < length; i++) {
                if (timeText[i] < '0' || timeText[i] > '9') {
                    numberEnd = i;
                    break;
                }
            }
            if (numberEnd == 0 || numberEnd > 8) {
                currentInfoLabel.ForeColor = Color.Red;
                currentInfoLabel.Text = "无效输入";
                if (timeInputTextbox.Text.Length == 0)
                    currentInfoLabel.Text = "";
                isInputValid = false;
            } else {
                currentInfoLabel.ForeColor = Color.Green;
                inputTimeSpan = parseTimeString(timeText.Substring(0, numberEnd));
                // todo
                currentInfoLabel.Text = getTimeSpanDescription(inputTimeSpan) + "后响铃";
                inputText = timeText.Substring(numberEnd).TrimStart(new char[] { ' ' });
                if (String.IsNullOrEmpty(inputText)) {
                    inputText = "(默认)";
                }
                isInputValid = true;
            }
        }


        /// <summary>
        /// 解析时间字符串，返回TimeSpan
        /// 如果字符串的长度小于等于2，则被识别为分钟
        /// 如果字符串长度位于3和4之间，则被识别为分钟+秒，末2位为秒，其余为分钟
        /// 如果字符串长度大于等于5，则末2位为秒，倒数3-4位为分钟，其余为小时
        /// </summary>
        /// <param name="timeStr"></param>
        /// <returns>一个TimeSpan对象，是字符串的解析结果</returns>
        internal static TimeSpan parseTimeString(string timeStr) {
            int hour = 0;
            int minute = 0;
            int second = 0;
            if (timeStr.Length <= 2) {          // 分钟
                minute = int.Parse(timeStr);
            } else if (timeStr.Length >= 5) {   // 小时:分钟:秒
                second = int.Parse(timeStr.Substring(timeStr.Length - 2));
                minute = int.Parse(timeStr.Substring(timeStr.Length - 4, 2));
                hour = int.Parse(timeStr.Substring(0, timeStr.Length - 4));
            } else {                            // 分钟:秒
                second = int.Parse(timeStr.Substring(timeStr.Length - 2));
                minute = int.Parse(timeStr.Substring(0, timeStr.Length - 2));
            }
            return new TimeSpan(hour, minute, second);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            } else {
                e.Cancel = true;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized) {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            dataGridView1.ClearSelection();
        }

        
    }

    class TimerManager {
        private List<Alarm> alarmList;
        private Timer timer;
        private int currentAlarm = -1;
        private Form1.NotificationDelegate notifier;
        private Form1.DataTableUpdateDelegate updateTable;

        public TimerManager(Timer timer, Form1.NotificationDelegate notifier, Form1.DataTableUpdateDelegate updateTable) {
            this.timer = timer;
            this.notifier = notifier;
            this.updateTable = updateTable;

            timer.Tick += timer1_Tick;
            alarmList = new List<Alarm>();
        }

        public void addAlarm(TimeSpan span, String message) {
            Alarm alarm = new Alarm();
            alarm.message = message;
            alarm.timeSpan = span;
            alarm.time = DateTime.Now + span;
            alarm.state = Alarm.RUNNING;
            alarmList.Add(alarm);
            adjustTimer();
            updateTable(alarmList);
        }

        private void adjustTimer() {
            DateTime? minTime = null;       // 加问号表示结构体可空
            DateTime now = DateTime.Now;
            currentAlarm = -1;
            for (int i = 0; i < alarmList.Count; i++) {
                Alarm alarm = alarmList[i];
                if (alarm.state == Alarm.RUNNING) {
                    if (alarm.state == Alarm.RUNNING && (minTime == null || (alarm.time < minTime.Value))) {
                        minTime = alarm.time;
                        currentAlarm = i;
                    }
                }
            }
            if (minTime == null) {
                timer.Enabled = false;
            } else {
                Console.WriteLine("min time is " + minTime.ToString());
                Console.WriteLine("now is " + now.ToString());
                Console.WriteLine("diff is " + (minTime - now));
                int diff = (int)((minTime - now).Value.TotalMilliseconds);
                if (diff <= 0) diff = 1000; // 过期的，1秒1个
                timer.Interval = diff;
                Console.WriteLine("set interval to " + timer.Interval);
                timer.Enabled = true;
            }
        }

        public void removeAlarm(int i) {
            if (i == currentAlarm) {
                alarmList.RemoveAt(i);
                adjustTimer();
            } else {
                alarmList.RemoveAt(i);
                if (i < currentAlarm) {
                    currentAlarm--;
                }
            }
            updateTable(alarmList);
        }

        public void timer1_Tick(object sender, EventArgs e) {
            timer.Enabled = false;
            Alarm alarm = alarmList[currentAlarm];
            notifier.Invoke(alarm.message);
            alarm.state = Alarm.DUE;
            Console.WriteLine("到时间了" + alarmList[currentAlarm].message);
            adjustTimer();
            updateTable(alarmList);
        }

        internal void startStopReset(int i) {
            Alarm alarm = alarmList[i];
            if (DateTime.Now >= alarmList[i].time) {
                if (alarm.state == Alarm.DUE) {
                    SelectTimeSpanForm form = new SelectTimeSpanForm();
                    form.defaultTimeSpan = alarm.timeSpan;
                    form.ShowDialog();
                    TimeSpan span = form.returnedTimeSpan;
                    form.Dispose();
                    Console.WriteLine("正在重置闹钟");
                    alarm.time = DateTime.Now + span;
                    alarm.state = Alarm.RUNNING;
                    adjustTimer();
                } else {
                    alarm.state = Alarm.DUE;
                }
            } else if (alarm.state == Alarm.RUNNING) {
                alarm.state = Alarm.STOPPED;
                if (i == currentAlarm) {
                    adjustTimer();
                }
            } else if (alarm.state == Alarm.STOPPED) {
                alarm.state = Alarm.RUNNING;
                if (currentAlarm == -1 || alarm.time < alarmList[currentAlarm].time) {
                    adjustTimer();
                }
            }
            updateTable(alarmList);
        }
    }

    public class Alarm {
        public DateTime time;                  // 目标时间戳
        public String message;
        public int state;
        public TimeSpan timeSpan;
        public const int RUNNING = 0;     // 正在进行
        public const int STOPPED = 1;     // 已停止
        public const int DUE = 2;         // 到期
        public static string getStateDescription(int state) {
            switch (state) {
                case RUNNING: return "正在进行";
                case STOPPED: return "已停止";
                case DUE: return "已过期";
                default: return "";
            }
        }
    }
}
