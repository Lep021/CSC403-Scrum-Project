using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTetris {
  public partial class FrmMain : Form {
    public FrmMain() {
      InitializeComponent();
    }

    private void tmrCurrentPieceFall_Tick(object sender, EventArgs e) {
      picTestPiece.Top += 30;
    }
  }
}
