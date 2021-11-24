//#define My_Debug
using shooting_01.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shooting_01
{
    public partial class MoleShooter : Form
    {
        const int Framenum = 13;
        const int Splatnum = 3;
        bool splat = false;
        int _gameFrame = 0;
        int _splatTime = 0;

        int _hits = 0;
        int _misses = 0;
        int _totalshots = 0;
        double _avarageHits = 0;
#if My_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif
        CMole _mole;
        CSplat _splat;
        CSign _sign;
        CScoreFrame _scoreFrame;

        Random rnd = new Random();
        public MoleShooter()
        {
            InitializeComponent();

            // Create scope site
            Bitmap b = new Bitmap(Resources.gun);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);
            _scoreFrame = new CScoreFrame() { Left = 30, Top = 30 };
            _sign = new CSign() { Left = 650, Top = 10 };
            _mole = new CMole() { Left = 120, Top = 300 };
            _splat = new CSplat();
        }

        private void TimerGameLoop_Tick(object sender, EventArgs e)
        {
            if (_avarageHits > 70.0)
            {
                if (_gameFrame >= Framenum-3)
                {
                    UpdateMole();
                    _gameFrame = 0;
                }
            }
            else if (_avarageHits > 80.0)
            {
                if (_gameFrame >= Framenum - 6)
                {
                    UpdateMole();
                    _gameFrame = 0;
                }
            }
            else if(_avarageHits < 33.0)
            {
                if (_gameFrame >= Framenum+6)
                {
                    UpdateMole();
                    _gameFrame = 0;
                }
            }
            else
            {
                if (_gameFrame >= Framenum)
                {
                    UpdateMole();
                    _gameFrame = 0;
                }
            }
            
            if (splat)
            {
                if(_splatTime >= Splatnum)
                {
                    splat = false;
                    _splatTime = 0;
                    UpdateMole();
                }
                _splatTime++;
            }
            _gameFrame++;
            this.Refresh();
            Refresh();
        }
        private void UpdateMole()
        {
            _mole.Update(
                rnd.Next(Resources.Mole.Width, this.Width - Resources.Mole.Width),
                rnd.Next(this.Height / 2, this.Height - Resources.Mole.Height * 2)
                );
        }

        private void MoleShooter_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics dc = e.Graphics;
            if (splat == true)
            {
                _splat.DrawImage(dc);
            }
            else
            {
                _mole.DrawImage(dc);
            }
            _sign.DrawImage(dc);
            _scoreFrame.DrawImage(dc);
            // put scores on screen
            TextFormatFlags flags = TextFormatFlags.Left;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, "SHOTS : " + _totalshots.ToString(), _font, new Rectangle(190, 90, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "HITS : " + _hits.ToString(), _font, new Rectangle(170, 120, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "MISSES : " + _misses.ToString(), _font, new Rectangle(190, 150, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "AVG : " + _avarageHits.ToString("F0") + "%", _font, new Rectangle(170, 180, 120, 20), SystemColors.ControlText, flags);
#if My_Debug
            TextFormatFlags flaags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _fonnt = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "x=" + _cursX.ToString() + ":" + "y=" + _cursY.ToString(), _fonnt,
                new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flaags);
#endif
            base.OnPaint(e);
        }

        private void MoleShooter_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            _cursX = e.X;
            _cursY = e.Y;
            this.Refresh();
#endif
            
        }

        private void MoleShooter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 770 && e.X < 850 && e.Y > 98 && e.Y < 125) //start Hot Spot
            {
                timerGameLoop.Start();
            }
            else if(e.X > 746 && e.X < 816 && e.Y > 156 && e.Y < 182) //stop Hot Spot
            {
                timerGameLoop.Stop();
            }
            else if (e.X > 750 && e.X < 860 && e.Y > 210 && e.Y < 237) //reset Hot Spot
            {
                timerGameLoop.Stop();
            }
            else if (e.X > 740 && e.X < 805 && e.Y > 266 && e.Y < 294) //exit Hot Spot
            {
                timerGameLoop.Stop();
            }
            else
            {
                if (_mole.Hit(e.X,e.Y))
                {
                    splat = true;
                    _splat.Left = _mole.Left - Resources.blood.Width / 500;
                    _splat.Top = _mole.Top - Resources.blood.Height / 3;
                    _hits++;
                }
                else
                {
                    _misses++;
                }
                _totalshots = _hits + _misses;
                _avarageHits = (double)_hits / (double)_totalshots * 100.0;
            }
            FireGun();
        }
        private void FireGun()
        {
            // Fire of the gun
            SoundPlayer simpleSound = new SoundPlayer(Resources.silencer);
            simpleSound.Play();

        }
    }
}
