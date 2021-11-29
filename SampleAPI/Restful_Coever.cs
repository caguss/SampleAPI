using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using MySql.Data.MySqlClient;

namespace SampleAPI
{
    public partial class Restful_Coever : Form
    {
        private string strAPI = "/CompanyUseage"; // API 설정
        private DataSet ds = new DataSet();
        private MessageForm err;
        DateTime last_record;
        public Restful_Coever()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            txtCompCode.Enabled = false;
            txtProjNum.Enabled = false;

            last_record = DateTime.Now;
            await SendMessage();

            timer1.Start();
        }

        private async Task SendMessage()
        {
            try
            {
                string strConn = "Server=m.coever.co.kr;Database=coever_mes_hwt;Uid=dbmes;Pwd=dbmes1!;"; //"Server=112.186.117.140;Database=coever_mes_hwt;Uid=dbmes;Pwd=dbmes1!;";

                using (MySqlConnection conn = new MySqlConnection(strConn))
                {
                    conn.Open();

                    CheckRowData(conn);
                }
            }
            catch (Exception)
            {
            }

            try
            {
                string url = "http://db2.coever.co.kr:21125/CompanyUseage";
                var httpContent = new System.Net.Http.StringContent("");
                HttpClient client = new System.Net.Http.HttpClient
                {
                    BaseAddress = new Uri(url)
                };


                //DATASET ds 수주,발주, 작지, 재고, 생산계획, 출하, 생산실적 순

                //A10 수주

                string data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                 "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                 "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                 "\"구분코드\":" + "\"" + "A10" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                 "\"로우갯수\":" + Convert.ToInt32(ds.Tables[0].Rows[0]["rowcount"].ToString()) + "," +
                                 "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[0].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                 "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[0].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                 "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                               "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                var response1 = await client.PostAsync(url, httpContent);

                //A20 발주

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A20" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[1].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[1].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[1].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);

                //A30 작지

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A30" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[2].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[2].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[2].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);

                //A40 재고

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A40" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[3].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[3].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[3].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);

                //A50 재고

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A50" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[3].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[3].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[3].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);

                //A60 출하

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A60" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[5].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[5].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[5].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);

                //A25 생산계획

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A25" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[4].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[4].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[4].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);

                //A26 생산실적

                data = "[{ \"회사코드\":" + "\"" + txtCompCode.Text + "\"" + "," + // 코에버 공통 1000? 1051?
                                "\"프로젝트번호\":" + Convert.ToInt32(txtProjNum.Text) + "," + // 프로젝트 번호  담당자 문의 or DB 확인 ( 업체 생성 PMS)
                                "\"날짜\": " + "\"" + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").ToString("yyyy-MM-dd") + "\"" + "," +
                                "\"구분코드\":" + "\"" + "A26" + "\"" + "," +  // 공통 코드 문서 참고 ( A10 : 수주 등등)
                                "\"로우갯수\":" + Convert.ToInt32(ds.Tables[6].Rows[0]["rowcount"].ToString()) + "," +
                                "\"최근등록일자\":" + "\"" + ((DateTime)ds.Tables[6].Rows[0]["reg_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"최근수정일자\":" + "\"" + ((DateTime)ds.Tables[6].Rows[0]["up_date"]).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "\"" + "," +
                                "\"비밀번호\":" + "\"" + "CoeverSmartFactoryCompanyUseage" + "\"" +
                              "}]";

                httpContent = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");

                response1 = await client.PostAsync(url, httpContent);
            }
            catch (Exception ex)
            {
                if (err.lasterr == "")
                {
                    err = new MessageForm("방찬석 불러와!!! :" + ex.Message);
                    err.ShowDialog();
                }
               
            }
        }

        private DataSet CheckRowData(MySqlConnection conn)
        {

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "CheckRowData_R10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter();

            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCompCode.Enabled = true;
            txtProjNum.Enabled = true;
            btnStart.Enabled = true;
            timer1.Stop();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (last_record.Day != DateTime.Now.Day)
            {
                await SendMessage();
            }
        }
    }
}
