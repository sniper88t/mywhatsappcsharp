using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;
using System.Net;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace mineapp
{
    public partial class frmMain : Form
    {
        string startupPath = System.IO.Directory.GetCurrentDirectory();
        string senderTNum = "";

        public frmMain()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            TwilioClient.Init(
                //Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID"),
                //Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")
                "ACf1b5b5cb06b3c075445ae20709a77335",
                "d612d87c3b13563b5cf7159ce5b57a32"
            );
            opt1.Checked = true;
            senderTNum = "+16479990328";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;

            var message = MessageResource.Create(
                from: new PhoneNumber("whatsapp:+14155238886"),
                to: new PhoneNumber("whatsapp:" + senderTNum),
                body: txtMsgContent.Text
            );

            Console.WriteLine("Message SID: " + message.Sid);

        }

        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton opt = (RadioButton)sender;
            if (opt.Checked)
            {
                switch (opt.Name)
                {
                    case "opt1":
                        //senderTNum = "+8613840493152";
                        senderTNum = "+16479990328";
                        break;
                    case "opt2":
                        senderTNum = "+380660402393";
                        break;
                }
            }
        }
    }
}
