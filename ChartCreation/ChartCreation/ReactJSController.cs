using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace ChartCreation
{
    
    [EnableCors(origins: "http://localhost:64314", headers: "*", methods: "*")]
    [RoutePrefix("api/ReactJS")]
    public class ReactJSController : ApiController
    {
        [HttpGet]
        public string GetAllDiseaseDetails()
        {
            string DiseaseDetails = string.Empty;
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
                SqlConnection connection = new SqlConnection(conStr);

                string Query = "EXEC GET_ALL_DISEASE_COUNT";

                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dtDiseases = new DataTable();
                dtDiseases.Load(reader);
                connection.Close();
                DiseaseDetails = JsonConvert.SerializeObject(dtDiseases, Formatting.Indented);
                return DiseaseDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public string GetByDisease(String disease)
        {
            string getDisease = string.Empty;
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
                SqlConnection connection = new SqlConnection(conStr);
                string Query = "EXEC GET_DISEASE_BYNAME " + "'" + disease + "'";

                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dtDiseases = new DataTable();
                dtDiseases.Load(reader);
                connection.Close();
                getDisease = JsonConvert.SerializeObject(dtDiseases, Formatting.Indented);
                return getDisease;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}