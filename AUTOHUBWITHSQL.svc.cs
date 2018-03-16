using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Mail;
using System.Net;
using System.Web.Script.Serialization;

namespace AutoHubWITHSQL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AUTOHUBWITHSQL" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AUTOHUBWITHSQL.svc or AUTOHUBWITHSQL.svc.cs at the Solution Explorer and start debugging.
    public class AUTOHUBWITHSQL : IAUTOHUBWITHSQL
    {
        ClsDataAccess ObjData = new ClsDataAccess();
        public Responce Login(string sEmail, string sPassword, int idusertype)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                sJson = ObjData.GetData("EXEC ProcLogin @email='" + sEmail + "',@Password='" + sPassword + "',@idusertype='" + idusertype + "',@flag='L'");
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = ex.Message.ToString();
            }
            return responce;
        }

        public Responce ResetPwd(string sEmail, string sPassword, string sOldPwd, int idusertype)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                sJson = ObjData.AlterDB("EXEC ProcLogin @email='" + sEmail + "',@Password='" + sPassword + "',@oldPwd='" + sOldPwd + "',@idusertype='" + idusertype + "',@flag='F'");
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = ex.Message.ToString();
            }
            return responce;
        }
        public CustomerDocs AlterCustomerDocument(string data)
        {
            CustomerDocs responce = new CustomerDocs();
            string sJson = "";

            try
            {
                CustomerDocument cusdoc = JsonConvert.DeserializeObject<CustomerDocument>(data);
                string sProstring = "EXEC ProcCustomerDocument @id='" + cusdoc.id + "',@Userid='" + cusdoc.Userid + "',@VehiclelNo='" + cusdoc.VehiclelNo + "'";
                sProstring += ",@VehicleType='" + cusdoc.VehicleType + "',@DocumentType='" + cusdoc.DocumentType + "',DocumentName='" + cusdoc.DocumentName + "' ,@flag='" + cusdoc.sFlag + "'";
                sJson = ObjData.AlterDB(sProstring);
                if (sJson.Equals("Sucess"))
                {
                    responce = GETCustomerDocument(Convert.ToInt32(cusdoc.Userid));
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = ex.Message.ToString();
            }
            return responce;
        }
        public CustomerDocs GETCustomerDocument(int iUserid)
        {
            CustomerDocs responce = new CustomerDocs();
            string sJson = "";

            try
            {
                string sProstring = "EXEC ProcCustomerDocument @Userid='" + iUserid + "',@flag='S'";
                sJson = ObjData.GetData(sProstring);
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce ALterTwoWheelerJobCart(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblTwowheelerJobCart JobCart = JsonConvert.DeserializeObject<tblTwowheelerJobCart>(sJobKart, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                sProstring.Append("Exec ProcTwoWellerJobCart @JobCardId   ='" + JobCart.JobCardId + "',@Customer_Name  ='" + JobCart.Customer_Name + "',");
                sProstring.Append(" @Garage_Name  ='" + JobCart.Garage_Name + "',@Vehicle_Number ='" + JobCart.Vehicle_Number + "',");
                sProstring.Append("@Vehichle_Brand_and_Model ='" + JobCart.Vehichle_Brand_and_Model + "',@Servicing_date ='" + (JobCart.Servicing_date) + "'");
                sProstring.Append(",@Garage_Mobile_Number ='" + JobCart.Garage_Mobile_Number + "',@Sent_To ='" + JobCart.Sent_To + "',@Labour_Charges ='" + JobCart.Labour_Charges + "'");
                sProstring.Append(",@Servicing_Charges ='" + JobCart.Servicing_Charges + "',@Servicing_ ='" + JobCart.Servicing_ + "',");
                sProstring.Append("@Engine_Oil ='" + JobCart.Engine_Oil + "',@washing ='" + JobCart.washing + "',@Servicing ='" + JobCart.Servicing + "',@D_Card_Spray ='" + JobCart.D_Card_Spray + "',");
                sProstring.Append("@Battery_Charges ='" + JobCart.Battery_Charges + "',@Gear_Box_Oil ='" + JobCart.Gear_Box_Oil + "',@Battery_Liner_Rear ='" + JobCart.Battery_Liner_Rear + "'");
                sProstring.Append(",@Battery_Liner_Front ='" + JobCart.Battery_Liner_Front + "',@Additional_Repair ='" + JobCart.Additional_Repair + "',");
                sProstring.Append("@Switch ='" + JobCart.Switch + "',@clutch_Plate ='" + JobCart.clutch_Plate + "',@Pressure_Plate ='" + JobCart.Pressure_Plate + "',");
                sProstring.Append("@Cable ='" + JobCart.Cable + "',@Bulb ='" + JobCart.Bulb + "',@Out ='" + JobCart.Out + "',@Oil_Seal ='" + JobCart.Oil_Seal + "',");
                sProstring.Append("@Greep_Cover ='" + JobCart.Greep_Cover + "',@Seat_cover ='" + JobCart.Seat_cover + "',");
                sProstring.Append("@Spring ='" + JobCart.Spring + "',@Breaing ='" + JobCart.Breaing + "',@Filter ='" + JobCart.Filter + "',");
                sProstring.Append("@Packing ='" + JobCart.Packing + "',@Rubber ='" + JobCart.Rubber + "',");
                sProstring.Append("@Gear ='" + JobCart.Gear + "',@Spark_Plug ='" + JobCart.Spark_Plug + "',@Chain_Spray ='" + JobCart.Chain_Spray + "',");
                sProstring.Append("@Assign_To ='" + JobCart.Assign_To + "',@Assembly ='" + JobCart.GAssembly + "',");
                sProstring.Append("@Problem_1 ='" + JobCart.Problem_1_ + "',@Problem_2 ='" + JobCart.Problem_2 + "',@Problem_3='" + JobCart.Problem_3 + "'");
                sProstring.Append(" ,@TotalCost='" + JobCart.TotalCost + "',@ModifiedBy='" + JobCart.ModifiedBy + "',@flag='" + JobCart.flag + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess"))
                {
                    responce = GETJobCart(sJobKart);
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETJobCart(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblTwowheelerJobCart JobCart = JsonConvert.DeserializeObject<tblTwowheelerJobCart>(sJobKart);
                sProstring.Append("EXEC ProcTwoWellerJobCart @JobCardId='" + JobCart.JobCardId + "',@Customer_Name='" + JobCart.Customer_Name + "',@Garage_Name='" + JobCart.Garage_Name + "',@flag='SA'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce ALterTwoWheelerAcceptance(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblTwoJobCartAcceptance JobCart = JsonConvert.DeserializeObject<tblTwoJobCartAcceptance>(sJobKart, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                sProstring.Append("EXEC ProcTwoJobCartAcceptance @id  ='" + JobCart.id + "',@JonCartId  = '" + JobCart.JonCartId + "',");
                sProstring.Append("@Labour_Charges  = '" + JobCart.Labour_Charges + "',@Servicing_Charges = '" + JobCart.Servicing_Charges + "',");
                sProstring.Append("@Servicing_= '" + JobCart.Servicing_ + "',@Engine_Oil= '" + JobCart.Engine_Oil + "',");
                sProstring.Append("@washing= '" + JobCart.washing + "',@Servicing= '" + JobCart.Servicing + "',");
                sProstring.Append("@D_Card_Spray= '" + JobCart.D_Card_Spray + "',@Battery_Charges= '" + JobCart.Battery_Charges + "',@Gear_Box_Oil= '" + JobCart.Gear_Box_Oil + "',");
                sProstring.Append("@Battery_Liner_Rear= '" + JobCart.Battery_Liner_Rear + "',@Battery_Liner_Front= '" + JobCart.Battery_Liner_Front + "',");
                sProstring.Append("@Additional_Repair= '" + JobCart.Additional_Repair + "',@Switch= '" + JobCart.Switch + "',@clutch_Plate= '" + JobCart.clutch_Plate + "',");
                sProstring.Append("@Pressure_Plate= '" + JobCart.Pressure_Plate + "',@Cable= '" + JobCart.Cable + "',@Bulb= '" + JobCart.Bulb + "',");
                sProstring.Append("@Out= '" + JobCart.Out + "',@Oil_Seal= '" + JobCart.Oil_Seal + "',@Greep_Cover= '" + JobCart.Greep_Cover + "',@Seat_cover= '" + JobCart.Seat_cover + "',");
                sProstring.Append("@Spring= '" + JobCart.Spring + "',@Breaing= '" + JobCart.Breaing + "',@Filter= '" + JobCart.Filter + "',@Packing= '" + JobCart.Packing + "',");
                sProstring.Append("@Rubber= '" + JobCart.Rubber + "',@Gear= '" + JobCart.Gear + "',@Spark_Plug= '" + JobCart.Spark_Plug + "',@Chain_Spray='" + JobCart.Chain_Spray + "',@flag='I'");
                sProstring.Append(",@addedBy='" + JobCart.addedBy + "',@status='" + JobCart.status + "',@send_to='" + JobCart.send_to + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess"))
                {
                    responce = GETJobCartCartAcceptance(sJobKart);
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETJobCartCartAcceptance(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblTwoJobCartAcceptance JobCart = JsonConvert.DeserializeObject<tblTwoJobCartAcceptance>(sJobKart);
                sProstring.Append("EXEC ProcTwoJobCartAcceptance @JonCartId='" + JobCart.JonCartId + "',@flag='S'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce ALterSentJobCart(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblJobCartSent JobCart = JsonConvert.DeserializeObject<tblJobCartSent>(sJobKart);
                sProstring.Append("EXEC ProcJobCartSent  @JobCardId  = '" + JobCart.JobCardId + "',");
                sProstring.Append("@SentTo  = '" + JobCart.SentTo + "',@flag='" + JobCart.flag + "',@JobCartType='" + JobCart.JobCartType + "'");

                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce ALterGaragePickupandDrop(string sPickupandDrops)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                PickupandDrop sPickupandDrop = JsonConvert.DeserializeObject<PickupandDrop>(sPickupandDrops);
                sProstring.Append("EXEC ProcGaragePickupandDrop  @GarageId  = '" + sPickupandDrop.GarageId + "',");
                sProstring.Append("@GTime  = '" + sPickupandDrop.GTime + "',@flag='" + sPickupandDrop.flag + "',@No_slovt='" + sPickupandDrop.No_slovt + "'");
                sProstring.Append("@PDtyp  = '" + sPickupandDrop.PDtyp + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess"))
                {
                    GetGaragePickupandDrop(sPickupandDrops);
                }
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GetGaragePickupandDrop(string sPickupandDrops)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                PickupandDrop sPickupandDrop = JsonConvert.DeserializeObject<PickupandDrop>(sPickupandDrops);
                sProstring.Append("EXEC ProcGaragePickupandDrop  @GarageId  = '" + sPickupandDrop.GarageId + "',");
                sProstring.Append("@GTime  = '" + sPickupandDrop.GTime + "',@flag='s''");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce AlterUser(string sData)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                Users Users = JsonConvert.DeserializeObject<Users>(sData, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                sProstring.Append("EXEC ProcUser ");
                sProstring.Append("@firstName='" + Users.firstName + "',@lastName='" + Users.lastName + "',@customerCompany='" + Users.customerCompany + "',@mobile='" + Users.mobile + "', ");
                sProstring.Append("@email='" + Users.email + "',@password='" + Users.password + "',@address='" + Users.address + "',@landMark='" + Users.landMark + "',@zip='" + Users.zip + "',@state='" + Users.state + "', ");
                sProstring.Append("@city='" + Users.city + "',@countryCode='" + Users.countryCode + "',@idUserType='" + Users.idUserType + "',@addedby='" + Users.addedby + "',@dateAdded='" + Users.dateAdded + "', ");
                sProstring.Append("@Gender='" + Users.Gender + "',@Dob='" + Users.Dob + "',@contact_person='" + Users.contact_person + "',@garage_establish_date='" + Users.garage_establish_date + "', ");
                sProstring.Append("@landline='" + Users.landline + "',@garage_location='" + Users.garage_location + "',@garage_longitude='" + Users.garage_longitude + "', ");
                sProstring.Append("@garage_latitude='" + Users.garage_latitude + "',@id='" + Users.id + "',@flag='" + Users.Flag + "'");

                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess") && Users.Flag.Equals("I"))
                {
                    SENDEMAIL(sData);
                    responce = GETUser(sData);
                }
                responce.Success = true;
                responce.Message = "User Added Sucessfully..!!!";
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETUser(string sData)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                Users cUsers = JsonConvert.DeserializeObject<Users>(sData);
                sProstring.Append("EXEC ProcUser @idUserType='1',@flag='S'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }


        public Responce ALterFourWheelerJobCart(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                TblFourWheelerJobCart JobCart = JsonConvert.DeserializeObject<TblFourWheelerJobCart>(sJobKart);
                sProstring.Append("EXEC ProcFourWheelerJobCart ");
                sProstring.Append(" @JobCartId= '" + JobCart.JobCartId + "',@Customer_Name= '" + JobCart.Customer_Name + "',	 ");
                sProstring.Append("@Garage_Name= '" + JobCart.Garage_Name + "',@Vehicle_Number= '" + JobCart.Vehicle_Number + "', ");
                sProstring.Append("@Vehichle_Brand_and_Model= '" + JobCart.Vehichle_Brand_and_Model + "', ");
                sProstring.Append("@Servicing_date= '" + JobCart.Servicing_date + "',@Garage_Mobile_Number= '" + JobCart.Garage_Mobile_Number + "', ");
                sProstring.Append("@Labour_Charges= '" + JobCart.Labour_Charges + "',@Servicing_Charges= '" + JobCart.Servicing_Charges + "', ");
                sProstring.Append("@Engine_Oil= '" + JobCart.Engine_Oil + "',@washing= '" + JobCart.washing + "', ");
                sProstring.Append("@Servicing= '" + JobCart.Servicing + "',@D_Card_Spray= '" + JobCart.D_Card_Spray + "', ");
                sProstring.Append("@Battery_Charges= '" + JobCart.Battery_Charges + "',@Gear_Box_Oil= '" + JobCart.Gear_Box_Oil + "', ");
                sProstring.Append("@Battery_Liner_Rear= '" + JobCart.Battery_Liner_Rear + "',@Battery_Liner_Front= '" + JobCart.Battery_Liner_Front + "', ");
                sProstring.Append("@Additonal_Repairs= '" + JobCart.Additonal_Repairs + "',@Coolent_Oil_Check= '" + JobCart.Coolent_Oil_Check + "', ");
                sProstring.Append("@Accelerator_Breaks= '" + JobCart.Accelerator_Breaks + "',@Ignition_Time_Idle_RPM_Check= '" + JobCart.Ignition_Time_Idle_RPM_Check + "', ");
                sProstring.Append("@Oil_Filter_Check= '" + JobCart.Oil_Filter_Check + "',@Steering_Pinion_Leaks= '" + JobCart.Steering_Pinion_Leaks + "',@Fule_Injector_and_Engine_Belts_Check= '" + JobCart.Fule_Injector_and_Engine_Belts_Check + "', ");
                sProstring.Append("@Car_Vaccum_Cleaning_Full_Interior= '" + JobCart.Car_Vaccum_Cleaning_Full_Interior + "', ");
                sProstring.Append("@Dashboard_Cleaning= '" + JobCart.Dashboard_Cleaning + "',@Air_conditioner_check= '" + JobCart.Air_conditioner_check + "', ");
                sProstring.Append("@Car_wash= '" + JobCart.Car_wash + "',@vehicle_performance_check= '" + JobCart.vehicle_performance_check + "', ");
                sProstring.Append("@Lunricants_to_Joints_Bolts= '" + JobCart.Lunricants_to_Joints_Bolts + "', ");
                sProstring.Append("@Wiper_Inspection_and_Fluid_Check= '" + JobCart.Wiper_Inspection_and_Fluid_Check + "',@Headlight_setting= '" + JobCart.Headlight_setting + "', ");
                sProstring.Append("@Indicator_Check= '" + JobCart.Indicator_Check + "',@Break_oil_level_check= '" + JobCart.Break_oil_level_check + "', ");
                sProstring.Append("@Engine_Oil_Level_Check= '" + JobCart.Engine_Oil_Level_Check + "', ");
                sProstring.Append("@Shock_Absorber_Oil= '" + JobCart.Shock_Absorber_Oil + "',@Manual_Transmission_Oil_Check= '" + JobCart.Manual_Transmission_Oil_Check + "', ");
                sProstring.Append("@Electrical_Connections_Joints_Check= '" + JobCart.Electrical_Connections_Joints_Check + "', ");
                sProstring.Append("@Problem_1= '" + JobCart.Problem_1 + "',@Problem_2= '" + JobCart.Problem_2 + "',@Problem_3= '" + JobCart.Problem_3 + "',");
                sProstring.Append("@Status='" + JobCart.Status + "', @flag ='" + JobCart.flag + "',@ModifiedBy='" + JobCart.ModifiedBy + "' ");
                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess"))
                {
                    responce = GETFourJobCart(sJobKart);
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETFourJobCart(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                TblFourWheelerJobCart JobCart = JsonConvert.DeserializeObject<TblFourWheelerJobCart>(sJobKart);
                if (JobCart.JobCartId.Equals(0))
                    sProstring.Append("EXEC ProcFourWheelerJobCart @Customer_Name='" + JobCart.Customer_Name + "',@Garage_Name='" + JobCart.Garage_Name + "',@flag='S'");
                else
                    sProstring.Append("EXEC ProcFourWheelerJobCart @JobCartId='" + JobCart.JobCartId + "',@flag='Sj'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }



        public Responce ALterFourWheelerAcceptance(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                TblFourWheelerAccepatance JobCart = JsonConvert.DeserializeObject<TblFourWheelerAccepatance>(sJobKart);
                sProstring.Append("EXEC ProcFourWheelerAccepatance ");
                sProstring.Append("@id = '" + JobCart.id + "', ");
                sProstring.Append("@JobCartId = '" + JobCart.JobCartId + "', ");
                sProstring.Append("@Labour_Charges = '" + JobCart.Labour_Charges + "', ");
                sProstring.Append("@Servicing_Charges = '" + JobCart.Servicing_Charges + "', ");
                sProstring.Append("@Servicing = '" + JobCart.Servicing + "', ");
                sProstring.Append("@Engine_Oil = '" + JobCart.Engine_Oil + "', ");
                sProstring.Append("@washing  = '" + JobCart.washing + "', ");
                sProstring.Append("@D_Card_Spray = '" + JobCart.D_Card_Spray + "', ");
                sProstring.Append("@Battery_Charges = '" + JobCart.Battery_Charges + "', ");
                sProstring.Append("@Gear_Box_Oil = '" + JobCart.Gear_Box_Oil + "', ");
                sProstring.Append("@Battery_Liner_Rear = '" + JobCart.Battery_Liner_Rear + "', ");
                sProstring.Append("@Battery_Liner_Front = '" + JobCart.Battery_Liner_Front + "', ");
                sProstring.Append("@Additonal_Repairs = '" + JobCart.Additonal_Repairs + "', ");
                sProstring.Append("@Coolent_Oil_Check = '" + JobCart.Coolent_Oil_Check + "', ");
                sProstring.Append("@Accelerator_Breaks = '" + JobCart.Accelerator_Breaks + "', ");
                sProstring.Append("@Ignition_Time_Idle_RPM_Check = '" + JobCart.Ignition_Time_Idle_RPM_Check + "', ");
                sProstring.Append("@Oil_Filter_Check = '" + JobCart.Oil_Filter_Check + "', ");
                sProstring.Append("@Steering_Pinion_Leaks = '" + JobCart.Steering_Pinion_Leaks + "', ");
                sProstring.Append("@Fule_Injector_and_Engine_Belts_Check = '" + JobCart.Fule_Injector_and_Engine_Belts_Check + "', ");
                sProstring.Append("@Car_Vaccum_Cleaning_Full_Interior = '" + JobCart.Car_Vaccum_Cleaning_Full_Interior + "', ");
                sProstring.Append("@Dashboard_Cleaning = '" + JobCart.Dashboard_Cleaning + "', ");
                sProstring.Append("@Air_conditioner_check = '" + JobCart.Air_conditioner_check + "', ");
                sProstring.Append("@Car_wash = '" + JobCart.Car_wash + "', ");
                sProstring.Append("@vehicle_performance_check = '" + JobCart.vehicle_performance_check + "', ");
                sProstring.Append("@Lunricants_to_Joints_Bolts = '" + JobCart.Lunricants_to_Joints_Bolts + "', ");
                sProstring.Append("@Wiper_Inspection_and_Fluid_Check = '" + JobCart.Wiper_Inspection_and_Fluid_Check + "', ");
                sProstring.Append("@Headlight_setting = '" + JobCart.Headlight_setting + "', ");
                sProstring.Append("@Indicator_Check = '" + JobCart.Indicator_Check + "', ");
                sProstring.Append("@Break_oil_level_check = '" + JobCart.Break_oil_level_check + "', ");
                sProstring.Append("@Engine_Oil_Level_Check = '" + JobCart.Engine_Oil_Level_Check + "', ");
                sProstring.Append("@Shock_Absorber_Oil = '" + JobCart.Shock_Absorber_Oil + "', ");
                sProstring.Append("@Manual_Transmission_Oil_Check = '" + JobCart.Manual_Transmission_Oil_Check + "', ");
                sProstring.Append("@Electrical_Connections_Joints_Check= '" + JobCart.Electrical_Connections_Joints_Check + "', ");
                sProstring.Append("@flag='" + JobCart.flag + "',@send_to='" + JobCart.send_to + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess"))
                {
                    responce = GETFourJobCartAcceptance(sJobKart);
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }

        public Responce GETFourJobCartAcceptance(string sJobKart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                TblFourWheelerAccepatance JobCart = JsonConvert.DeserializeObject<TblFourWheelerAccepatance>(sJobKart);
                if (JobCart.JobCartId.Equals(0))
                    sProstring.Append("EXEC ProcFourWheelerAccepatance @JobCartId='" + JobCart.JobCartId + "',@flag='S'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }

        public Responce SENDEMAIL(string Semail)
        {
            Responce responce = new Responce();
            try
            {
                SendEmail Clsemail = JsonConvert.DeserializeObject<SendEmail>(Semail);
                string strBody = "Hello " + Clsemail.sName + ", \n";
                strBody += " Congratulation your account has been successfully created Below are the Credentials \n";
                strBody += " User name: " + Clsemail.sEmailid + " \n";
                strBody += "Password:autohub@123 \n";
                strBody += " Regards,\n AutoHub";
                MailAddress senderaddr = new MailAddress(Clsemail.sEmailid, "AUto Hub Services");
                MailAddress recaddress = new MailAddress(Clsemail.sEmailid);
                MailMessage mymail = new MailMessage();
                mymail.To.Add(recaddress);
                mymail.Headers.Add("reply-to", "AUTO HUB Services");
                mymail.From = senderaddr;
                mymail.Body = strBody;
                mymail.Subject = "User Registration Details";
                SmtpClient s = new SmtpClient();
                s.Host = "smtp.gmail.com";
                s.UseDefaultCredentials = true;
                s.Port = 587;
                s.Credentials = new NetworkCredential("autohubservices2018@gmail.com", "autohub123");
                s.EnableSsl = true;
                s.Send(mymail);
                responce.Message = "Email Send Sucessfully....!!!";
                responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message.ToString();
                responce.Success = true;
            }
            return responce;
        }


        public Responce sendOTP(string sData)
        {
            Responce responce = new Responce();
            try
            {
                StringBuilder sbSMS = new StringBuilder();
                SendOTP sms = JsonConvert.DeserializeObject<SendOTP>(sData);
                sbSMS.Append("http://bhashsms.com/api/sendmsg.php?user=OTGS&pass=ganapati2017&sender=OTGSAU&phone=" + (sms.mobileno) + " phone no&text=" + sms.sMessage + "&priority=ndnd&stype=normal");
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(sbSMS.ToString());
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
                responce.Message = "SMS Send Sucessfully....!!!";
                responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message.ToString();
                responce.Success = true;
            }
            return responce;
        }

        public Responce ALterGarageRating(string sRating)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblRatings Rating = JsonConvert.DeserializeObject<tblRatings>(sRating);
                sProstring.Append("EXEC ProcRatings @NoofRatings='" + Rating.NoofRatings + "',@Review='" + Rating.Review + "',@flag='I',");
                sProstring.Append("@Custid='" + Rating.Custid + "',@GarageId ='" + Rating.GarageId + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                if (sJson.Equals("Sucess"))
                {
                    responce = GETGarageRating(sRating);
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETGarageRating(string sRating)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblRatings Rating = JsonConvert.DeserializeObject<tblRatings>(sRating);
                sProstring.Append("EXEC ProcRatings @flag='S', @Custid='" + Rating.Custid + "',@GarageId ='" + Rating.GarageId + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }

        public Responce ALterFavourite(string sfavourite)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblfavourite favourite = JsonConvert.DeserializeObject<tblfavourite>(sfavourite);
                sProstring.Append("EXEC PROCfavourite @CustId='" + favourite.CustId + "',@GaragId='" + favourite.GaragId + "',@flag='I',");
                sProstring.Append("@isFavourite='" + favourite.isFavourite + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                if (sJson.Equals("Sucess"))
                {
                    responce = GETFavouriteGarge(sfavourite);
                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETFavouriteGarges(string sfavourite)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblfavourite favourite = JsonConvert.DeserializeObject<tblfavourite>(sfavourite);
                sProstring.Append("EXEC PROCfavourite @flag='s', @GaragId='" + favourite.GaragId + "',@CustId='" + favourite.CustId + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETFavouriteGarge(string sfavourite)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                tblfavourite favourite = JsonConvert.DeserializeObject<tblfavourite>(sfavourite);
                sProstring.Append("EXEC PROCfavourite @flag='" + favourite.flag + "', @GaragId='" + favourite.GaragId + "',@CustId='" + favourite.CustId + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GETGargeLocation(string sfavourite)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                GEtlocation favourite = JsonConvert.DeserializeObject<GEtlocation>(sfavourite);
                if (favourite.flag.Equals("G"))
                    sProstring.Append("EXEC GetGarageLocation @flag='G', @garage_longitude='" + favourite.garage_longitude + "',@garage_latitude='" + favourite.garage_latitude + "'");
                else
                    sProstring.Append("EXEC GetGarageLocation @flag='GD', @GarageId='" + favourite.GaragId + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GetChannelPatnerWisedata(string sPatner)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                GEtlocation favourite = JsonConvert.DeserializeObject<GEtlocation>(sPatner);
                sProstring.Append("EXEC GetGarageLocation @flag='GCP', @addedby='" + favourite.addedby + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }

        public Responce GetDetailsFourwheelerData(string sJobcart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                JobCartParameters Jobcart = JsonConvert.DeserializeObject<JobCartParameters>(sJobcart);
                sProstring.Append("EXEC ProcFourWheelerJobCart @flag='" + Jobcart.flag + "', @custid='" + Jobcart.custid + "',@JonCartId='" + Jobcart.custid + "',");
                sProstring.Append(",@LogId='" + Jobcart.Logid + "', @Garageid ='" + Jobcart.Garageid + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;

        }

        public Responce GetDetailsData(string sJobcart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                JobCartParameters Jobcart = JsonConvert.DeserializeObject<JobCartParameters>(sJobcart);
                sProstring.Append("EXEC ProGetData @flag='" + Jobcart.flag + "', @custid='" + Jobcart.custid + "',");
                sProstring.Append("@Garageid ='" + Jobcart.Garageid + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;

        }


        public Responce GetDetailsTwowheelerData(string sJobcart)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                JobCartParameters Jobcart = JsonConvert.DeserializeObject<JobCartParameters>(sJobcart);
                sProstring.Append("EXEC ProcTwoWellerJobCart @flag='" + Jobcart.flag + "', @custid='" + Jobcart.custid + "',@JonCartId='" + Jobcart.custid + "',");
                sProstring.Append(",@LogId='" + Jobcart.Logid + "', @Garageid ='" + Jobcart.Garageid + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;

        }
        public Responces CreateOrder(string OrderData)
        {
            Responces response = new Responces();
            string sJson = "";
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();

                Orders order = JsonConvert.DeserializeObject<Orders>(OrderData);
                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("exec ProcOrder ");
                sProstring.Append("@idUser='" + order.idUser + "',@idGarage='" + order.idGarage + "',@vehicleType='" + order.vehicleType + "',@Brand='" + order.Brand + "',");
                sProstring.Append("@OrderStatus='" + order.OrderStatus + "',@Notes='" + order.Notes + "',@Orderdate='" + order.Orderdate + "',");
                sProstring.Append("@ServiceDate='" + order.ServiceDate + "',@VehicleNumber='" + order.VehicleNumber + "',@IsPickUp='" + order.IsPickUp + "'");
                sProstring.Append(",@TimeSlovet='" + order.TimeSlovet + "' ,@flag='" + order.flag + "', @idOrder='" + order.idOrder + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                if (sJson.Equals("Sucess"))
                {
                    response = GetOrder(OrderData);
                }
                else
                {
                    response.Message = "Failed";
                    response.Error = sJson;
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while order creation";
                response.Error = ex.Message;
            }
            return response;
        }
        public Responces CancelOrder(int iOrderid)
        {
            Responces response = new Responces();
            string sJson = "";
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();


                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("exec ProcOrder @idOrder='" + iOrderid + "'");
                sProstring.Append("@flag='CancledOrder'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                if (sJson.Equals("Sucess"))
                {
                    sProstring.Append("exec ProcOrder @idOrder='" + iOrderid + "',");
                    sProstring.Append("@flag='GetCancledOrder'");
                    sJson = ObjData.GetData(sProstring.ToString());
                    response.Data = sJson;
                }
                else
                {
                    response.Message = "Failed";
                    response.Error = sJson;
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while order creation";
                response.Error = ex.Message;
            }
            return response;
        }
        public Responces GetOrder(string OrderData)
        {
            Responces response = new Responces();
            string sJson = "";
            try
            {
                Orders order = JsonConvert.DeserializeObject<Orders>(OrderData);
                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("exec ProcOrder ");
                if (order.flag.Equals("U"))
                    sProstring.Append("@idUser='" + order.idUser + "',@idGarage='" + order.idGarage + "',@flag='SID',@type='" + order.type + "'");
                else if (order.flag.Equals("I"))
                    sProstring.Append("@idUser='" + order.idUser + "',@idGarage='" + order.idGarage + "',@flag='S',@type='" + order.type + "'");
                else
                    sProstring.Append("@idUser='" + order.idUser + "',@idGarage='" + order.idGarage + "',@flag='" + order.flag + "',@type='" + order.type + "',@idOrder='" + order.idOrder + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                response.Data = sJson;
                response.Success = true;
                response.Error = "";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public Responces GetJobCartDetails(string soDetails)
        {
            Responces response = new Responces();
            string sJson = "";
            try
            {
                GETJobDetails oDetails = JsonConvert.DeserializeObject<GETJobDetails>(soDetails);
                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("exec GetJobCartDetails ");
                sProstring.Append("@Customer_Name='" + oDetails.idCustomer + "',@Garage_Name='" + oDetails.idGarage + "',@flag='" + oDetails.flag + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                response.Data = sJson;
                response.Success = true;
                response.Error = "";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public Responces GetForeJobCartDetails(string soDetails)
        {
            Responces response = new Responces();
            string sJson = "";
            try
            {
                GETJobDetails oDetails = JsonConvert.DeserializeObject<GETJobDetails>(soDetails);
                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("exec ProcFourWheelerJobCart ");
                sProstring.Append("@Customer_Name='" + oDetails.idCustomer + "',@Garage_Name='" + oDetails.idGarage + "',@flag='" + oDetails.flag + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                response.Data = sJson;
                response.Success = true;
                response.Error = "";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public Responces GetTwoJobCartDetails(string soDetails)
        {
            Responces response = new Responces();
            string sJson = "";
            try
            {
                GETJobDetails oDetails = JsonConvert.DeserializeObject<GETJobDetails>(soDetails);
                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("exec ProcTwoWellerJobCart ");
                sProstring.Append("@Customer_Name='" + oDetails.idCustomer + "',@Garage_Name='" + oDetails.idGarage + "',@flag='" + oDetails.flag + "'");
                sJson = ObjData.GetData(sProstring.ToString());
                response.Data = sJson;
                response.Success = true;
                response.Error = "";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }
        public Responce ALterSHOTDISTRIBUTERS(string sSHOTDISTRIBUTERS)
        {
            Responce responce = new Responce();
            string sJson = "";

            try
            {
                StringBuilder sProstring = new StringBuilder();
                SHOTDISTRIBUTERS SHOTDISTRIBUTERS = JsonConvert.DeserializeObject<SHOTDISTRIBUTERS>(sSHOTDISTRIBUTERS);
                sProstring.Append("EXEC USP_INSERT_SHOTDISTRIBUTERS @ParentId='" + SHOTDISTRIBUTERS.ParentId + "',@Shot_Type='" + SHOTDISTRIBUTERS.Shot_Type + "',@UserName='" + SHOTDISTRIBUTERS.UserName + "',");
                sProstring.Append("@Paid_Amount='" + SHOTDISTRIBUTERS.Paid_Amount + "',@BC_Cd ='" + SHOTDISTRIBUTERS.BC_Cd + "',@prnt_BC_Cd='" + SHOTDISTRIBUTERS.prnt_BC_Cd + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                if (sJson.Equals("Sucess"))
                {
                    responce.Message = "SHOT DISTRIBUTERS Entry Completed Processing Comission";

                }
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce ALterGarageTime(string sTImeSlovet)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                TImeSlovet sTImeSlovets = JsonConvert.DeserializeObject<TImeSlovet>(sTImeSlovet);
                sProstring.Append("EXEC ProcTimeslovet  @GarageId  = '" + sTImeSlovets.garegid + "',");
                sProstring.Append("@noofdrops  = '" + sTImeSlovets.noofdrops + "',@pdFlag='" + sTImeSlovets.pdFlag + "'");
                sProstring.Append("@Timeslovt  = '" + sTImeSlovets.Timeslovt + "'");
                sJson = ObjData.AlterDB(sProstring.ToString());
                responce.Data = sJson;
                if (sJson.Equals("Sucess"))
                {
                    GetGaragePickupandDrop(sTImeSlovet);
                }
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
        public Responce GetGarageTime(string sPickupandDrops)
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                PickupandDrop sPickupandDrop = JsonConvert.DeserializeObject<PickupandDrop>(sPickupandDrops);
                sProstring.Append("EXEC ProcTimeslovet  @GarageId  = '" + sPickupandDrop.GarageId + "',@flag='S'");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }

        public Responce GetGarageTimeMaster()
        {
            Responce responce = new Responce();
            string sJson = "";
            try
            {
                StringBuilder sProstring = new StringBuilder();
                sProstring.Append("select * from [OTGS_DB_User].[TblTimeslovetMaster]");
                sJson = ObjData.GetData(sProstring.ToString());
                responce.Data = sJson;
                responce.Success = true;
                responce.Error = "";
            }
            catch (Exception ex)
            {
                sJson = " Faild";
                responce.Error = ex.Message.ToString() + sJson;
            }
            return responce;
        }
    }

}

