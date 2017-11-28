using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services
{
    public class ServiceConstants
    {
        public const int PageSize = 25;

        //TODO read from file.
        public const string PdfCertificateFormat = @"<body style=""margin:50px;text-align:center; border: 10px solid #787878"" >
<div style=""background:#cce6ff;margin:50px; text-align:center; border: 5px solid #787878"" >
       <span style=""font-size:30px;margin-top:40px; font-weight:bold"">Certificate</span>
       <br/><br/>
       <span style=""font-size:25px""><i>This is to certify that</i></span>
       <br><br>
       <span style=""font-size:30px""><b>{0}</b></span><br/><br/>
       <span style=""font-size:25px""><i>has completed the course</i></span><br/><br/>
       <span style=""font-size:30px""> {1} </span><br/><br/>
       < span style=""font-size:20px""> with score of <b>{2}</b></span><br/><br/><br/><br/>
       <span style=""font-size:25px""><i> Trainer - {3} </ i ></span><br/>
      < span style=""font-size:30px"">{4} - {5}</span>
</ div >
</ body > ";
    }
}
