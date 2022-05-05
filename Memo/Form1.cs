using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Memo
{
    public partial class Form1 : Form
    {

        private Boolean txtNoteChange;  //바뀐 내용 체크
        private string fWord;   //찾기 문자열
        private Form2 frm2; //찾기 창
        public Form1()
        {
            InitializeComponent();
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)   //새로 만들기를 눌러 생성
        {
            if(this.txtNoteChange==true)    //저장된 파일과 내용이 다르거나 or 저장된 파일이 없을 때
            {
                var msg = this.Text + "파일의 내용이 변경되었습니다. " + "\r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if(dlr == DialogResult.Yes) //저장 후 새 파일
                {
                    textSave();
                    this.txtNote.ResetText();
                    this.Text = "제목 없음";
                    this.txtNoteChange = false;
                }
                else if(dlr == DialogResult.No) //변경된 내용을 저장하지 않고 새 파일
                {
                    this.txtNote.ResetText();
                    this.Text = "제목 없음";
                    this.txtNoteChange = false;
                }
                else if(dlr == DialogResult.Cancel) //새로 만들기 취소
                    return;
                else    //예외
                {
                    this.txtNote.ResetText();
                    this.Text = "제목 없음";
                    this.txtNoteChange = false;
                }
            }
            else    //변경된 내용이 없음
            {
                this.txtNote.ResetText();
                this.Text = "제목 없음";
                this.txtNoteChange = false;
            }
        }

        private void textSave()
        {
            if(this.Text=="제목 없음")  //저장된 파일이 없음
            {
                var dlr = this.sfdFile.ShowDialog();
                if(dlr!=DialogResult.Cancel)    // 취소가 아니라면(저장을 누름)
                {
                    var str = this.sfdFile.FileName;
                    var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                    sw.Write(this.txtNote.Text);
                    sw.Flush();
                    this.Text = str;
                    this.txtNoteChange = false;
                }
            }
            else    //저장된 파일이 있으므로 해당 파일에 저장
            {
                var strt = this.Text;
                var sw = new StreamWriter(strt, false, System.Text.Encoding.Default);
                sw.Write(this.txtNote.Text);
                sw.Flush();
                sw.Close();
                this.Text = strt;
                this.txtNoteChange = false;
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.txtNoteChange==true)    //열린 메모장의 내용이 변경되었을 경우
            {
                var msg = this.Text + "파일의 내용이 변경되었습니다. " + "\r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    textSave();
                    textOpen();
                }
                else if (dlr == DialogResult.No)
                    textOpen(); //저장하지 않고 파일 열기 메서드 호출
                else if (dlr == DialogResult.Cancel)
                    return;
            }
            else    //수정된 내용이 없음
            {
                textOpen();
            }
        }

        private void textOpen()
        {
            var dr = this.ofdFile.ShowDialog();
            if(dr != DialogResult.Cancel)
            {
                var str = this.ofdFile.FileName;
                var sr = new StreamReader(str, System.Text.Encoding.Default);
                this.txtNote.Text = sr.ReadToEnd();
                sr.Close();
                this.Text = str;
                this.txtNoteChange = false;
            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            this.txtNoteChange = true;
        }

        private void 다른이름으로저장AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlr = this.sfdFile.ShowDialog();
            if(dlr!=DialogResult.Cancel)
            {
                var str = this.sfdFile.FileName;
                var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                sw.Write(this.txtNote.Text);
                sw.Flush();
                sw.Close();
                this.Text = str;
                this.txtNoteChange = false;
            }
        }

        private void 찾기FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!(frm2==null||!frm2.Visible))
            {
                frm2.Focus();
                return;
            }
            frm2 = new Form2();

            if (this.txtNote.SelectionLength == 0)
                frm2.txtWord.Text = this.fWord;
            else
                frm2.txtWord.Text = this.txtNote.SelectedText;
            frm2.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            frm2.Show();
        }

        private void 다음찾기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!(frm2==null||!frm2.Visible))
            {
                frm2.txtWord.Text = this.fWord;
                this.btnOk_Click(this, null);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var updown = -1;
            var str = this.txtNote.Text;
            var findWord = frm2.txtWord.Text;
            if(!frm2.cbOption.Checked)
            {
                str = str.ToUpper();
                findWord = findWord.ToUpper();
            }
            if (frm2.rdb01.Checked)
            {
                if (this.txtNote.SelectionStart != 0)
                    updown = str.LastIndexOf(findWord, this.txtNote.SelectionStart - 1);
            }
            else
                updown = str.IndexOf(findWord, this.txtNote.SelectionStart + this.txtNote.SelectionLength);
            if(updown==-1)
            {
                MessageBox.Show("더 이상 찾는 문자열이 없습니다.", "메모장", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.txtNote.Select(updown, findWord.Length);
            fWord = frm2.txtWord.Text;
            this.txtNote.Focus();
            this.txtNote.ScrollToCaret();
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textSave();
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 실행취소UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Undo();
        }

        private void 잘라내기TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Cut();
        }

        private void 복사CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Copy();
        }

        private void 붙여넣기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Paste();
        }

        private void 삭제LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.SelectedText = "";
        }

        private void 모두선택AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.SelectAll();
        }

        private void 시간날짜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToShortTimeString();
            var date = DateTime.Today.ToShortDateString();
            this.txtNote.AppendText(time + "/" + date);
        }

        private void 자동줄바꿈WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.WordWrap = !(this.txtNote.WordWrap);
            자동줄바꿈WToolStripMenuItem.Checked = !(자동줄바꿈WToolStripMenuItem.Checked);
        }

        private void 글꼴FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.fdText.ShowDialog() != DialogResult.Cancel)
            {
                this.txtNote.Font = this.fdText.Font;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (this.txtNoteChange == true)
            {
                var msg = this.Text + "파일의 내용이 변경되었습니다." + "\r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    if (this.Text == "제목 없음")
                    {
                        var dr = this.sfdFile.ShowDialog();
                        if (dr != DialogResult.Cancel)
                        {
                            var str = this.sfdFile.FileName;
                            var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                            sw.Write(this.txtNote.Text);
                            sw.Flush();
                            sw.Close();
                            this.txtNoteChange = false;
                        }
                    }
                    else
                    {
                        var str = this.Text;
                        var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                        sw.Write(this.txtNote.Text);
                        sw.Flush();
                        sw.Close();
                        this.txtNoteChange = false;
                    }
                    this.Dispose();
                }
                else if (dlr == DialogResult.No)
                    this.Dispose();
                else if (dlr == DialogResult.Cancel)
                    return;
            }
            else
                this.Dispose();
        }
    }
}
