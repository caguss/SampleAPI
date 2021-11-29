using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleAPI
{
    public partial class MessageForm : Form
    {
        public string lasterr = "";

        public MessageForm()
        {
            InitializeComponent();
        }
        public MessageForm(string errmsg)
        {
            InitializeComponent();
            lblerr.Text = errmsg;
            lasterr = errmsg;
            
        }

    }
}
