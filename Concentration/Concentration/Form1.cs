using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concentration {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e) {
            
        }

        private void Card0_Click(object sender, EventArgs e) {
            this.Card0.Text = "表";
        }

        private void Card0_KeyUp(object sender, KeyEventArgs e) {

        }
    }
}
