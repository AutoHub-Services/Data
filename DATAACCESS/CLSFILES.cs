using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoHubWITHSQL
{
    public class CustomerDocument
    {
        public int id { get; set; }
        public int? Userid { get; set; }
        public string VehiclelNo { get; set; }
        public string VehicleType { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentType { get; set; }
        public string sFlag { get; set; }
    }
    public class SendOTP
    {
        public string sMessage { get; set; }
        public string mobileno { get; set; }
    }
    public class tblTwowheelerJobCart
    {
        public int? JobCardId { get; set; }
        public int? Customer_Name { get; set; }
        public int? Garage_Name { get; set; }
        public string Vehicle_Number { get; set; }
        public string Vehichle_Brand_and_Model { get; set; }
        public string Servicing_date { get; set; }
        public string Garage_Mobile_Number { get; set; }
        public string Sent_To { get; set; }
        public decimal? Labour_Charges { get; set; }
        public decimal? Servicing_Charges { get; set; }
        public decimal? Servicing_ { get; set; }
        public decimal? Engine_Oil { get; set; }
        public decimal? washing { get; set; }
        public decimal? Servicing { get; set; }

        public decimal? TotalCost { get; set; }
        public decimal? D_Card_Spray { get; set; }
        public decimal? Battery_Charges { get; set; }
        public decimal? Gear_Box_Oil { get; set; }
        public decimal? Battery_Liner_Rear { get; set; }
        public decimal? Battery_Liner_Front { get; set; }
        public decimal? Additional_Repair { get; set; }
        public decimal? Switch { get; set; }
        public decimal? clutch_Plate { get; set; }
        public decimal? Pressure_Plate { get; set; }
        public decimal? Cable { get; set; }
        public decimal? Bulb { get; set; }
        public decimal? Out { get; set; }
        public decimal? Oil_Seal { get; set; }
        public decimal? Greep_Cover { get; set; }
        public decimal? Seat_cover { get; set; }
        public decimal? Spring { get; set; }
        public decimal? Breaing { get; set; }
        public decimal? Filter { get; set; }
        public decimal? Packing { get; set; }
        public decimal? Rubber { get; set; }
        public decimal? Gear { get; set; }
        public decimal? Spark_Plug { get; set; }
        public decimal? Chain_Spray { get; set; }
        public int? Assign_To { get; set; }
        public decimal? GAssembly { get; set; }
        public string Problem_1_ { get; set; }
        public string Problem_2 { get; set; }
        public string Problem_3 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string flag { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class tblTwoJobCartAcceptance
    {
        public int id { get; set; }
        public int? JonCartId { get; set; }
        public int? Labour_Charges { get; set; }
        public int? Servicing_Charges { get; set; }
        public int? Servicing_ { get; set; }
        public int? Engine_Oil { get; set; }
        public int? washing { get; set; }
        public int? Servicing { get; set; }
        public int? D_Card_Spray { get; set; }
        public int? Battery_Charges { get; set; }
        public int? Gear_Box_Oil { get; set; }
        public int? Battery_Liner_Rear { get; set; }
        public int? Battery_Liner_Front { get; set; }
        public int? Additional_Repair { get; set; }
        public int? Switch { get; set; }
        public int? clutch_Plate { get; set; }
        public int? Pressure_Plate { get; set; }
        public int? Cable { get; set; }
        public int? Bulb { get; set; }
        public int? Out { get; set; }
        public int? Oil_Seal { get; set; }
        public int? Greep_Cover { get; set; }
        public int? Seat_cover { get; set; }
        public int? Spring { get; set; }
        public int? Breaing { get; set; }
        public int? Filter { get; set; }
        public int? Packing { get; set; }
        public int? Rubber { get; set; }
        public int? Gear { get; set; }
        public int? Spark_Plug { get; set; }
        public int? Chain_Spray { get; set; }
        public string addedBy { get; set; }
        public string status { get; set; }
        public int send_to { get; set; }
    }
    public class tblJobCartSent
    {
        public int id { get; set; }
        public int? JobCardId { get; set; }
        public string SentTo { get; set; }
        public string flag { get; set; }

        public string JobCartType { get; set; }
    }

    public class Users
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string customerCompany { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string landMark { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }
        public int idUserType { get; set; }
        public int? addedby { get; set; }
        public DateTime? dateAdded { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string contact_person { get; set; }
        public DateTime? garage_establish_date { get; set; }
        public string landline { get; set; }
        public string garage_location { get; set; }
        public float? garage_longitude { get; set; }
        public float? garage_latitude { get; set; }
        public string Flag { get; set; }
    }

    public class TblFourWheelerJobCart
    {
        public int JobCartId { get; set; }
        public int? Customer_Name { get; set; }
        public int? Garage_Name { get; set; }
        public string Vehicle_Number { get; set; }
        public string Vehichle_Brand_and_Model { get; set; }
        public DateTime? Servicing_date { get; set; }
        public int? Garage_Mobile_Number { get; set; }
        public decimal? Labour_Charges { get; set; }
        public decimal? Servicing_Charges { get; set; }
        public decimal? Servicing { get; set; }
        public decimal? Engine_Oil { get; set; }
        public decimal? washing { get; set; }
        public decimal? D_Card_Spray { get; set; }
        public decimal? Battery_Charges { get; set; }
        public decimal? Gear_Box_Oil { get; set; }
        public decimal? Battery_Liner_Rear { get; set; }
        public decimal? Battery_Liner_Front { get; set; }
        public decimal? Additonal_Repairs { get; set; }
        public decimal? Coolent_Oil_Check { get; set; }
        public decimal? Accelerator_Breaks { get; set; }
        public decimal? Ignition_Time_Idle_RPM_Check { get; set; }
        public decimal? Oil_Filter_Check { get; set; }
        public decimal? Steering_Pinion_Leaks { get; set; }
        public decimal? Fule_Injector_and_Engine_Belts_Check { get; set; }
        public decimal? Car_Vaccum_Cleaning_Full_Interior { get; set; }
        public decimal? Dashboard_Cleaning { get; set; }
        public decimal? Air_conditioner_check { get; set; }
        public decimal? Car_wash { get; set; }
        public decimal? vehicle_performance_check { get; set; }
        public decimal? Lunricants_to_Joints_Bolts { get; set; }
        public decimal? Wiper_Inspection_and_Fluid_Check { get; set; }
        public decimal? Headlight_setting { get; set; }
        public decimal? Indicator_Check { get; set; }
        public decimal? Break_oil_level_check { get; set; }
        public decimal? Engine_Oil_Level_Check { get; set; }
        public decimal? Shock_Absorber_Oil { get; set; }
        public decimal? Manual_Transmission_Oil_Check { get; set; }
        public decimal? Electrical_Connections_Joints_Check { get; set; }
        public string Problem_1 { get; set; }
        public string Problem_2 { get; set; }
        public string Problem_3 { get; set; }
        public string flag { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
        public int logid { get; set; }
    }


    public class TblFourWheelerAccepatance
    {
        public int? id { get; set; }
        public int? JobCartId { get; set; }
        public int? Labour_Charges { get; set; }
        public int? Servicing_Charges { get; set; }
        public int? Servicing { get; set; }
        public int? Engine_Oil { get; set; }
        public int? washing { get; set; }
        public int? D_Card_Spray { get; set; }
        public int? Battery_Charges { get; set; }
        public int? Gear_Box_Oil { get; set; }
        public int? Battery_Liner_Rear { get; set; }
        public int? Battery_Liner_Front { get; set; }
        public int? Additonal_Repairs { get; set; }
        public int? Coolent_Oil_Check { get; set; }
        public int? Accelerator_Breaks { get; set; }
        public int? Ignition_Time_Idle_RPM_Check { get; set; }
        public int? Oil_Filter_Check { get; set; }
        public int? Steering_Pinion_Leaks { get; set; }
        public int? Fule_Injector_and_Engine_Belts_Check { get; set; }
        public int? Car_Vaccum_Cleaning_Full_Interior { get; set; }
        public int? Dashboard_Cleaning { get; set; }
        public int? Air_conditioner_check { get; set; }
        public int? Car_wash { get; set; }
        public int? vehicle_performance_check { get; set; }
        public int? Lunricants_to_Joints_Bolts { get; set; }
        public int? Wiper_Inspection_and_Fluid_Check { get; set; }
        public int? Headlight_setting { get; set; }
        public int? Indicator_Check { get; set; }
        public int? Break_oil_level_check { get; set; }
        public int? Engine_Oil_Level_Check { get; set; }
        public int? Shock_Absorber_Oil { get; set; }
        public int? Manual_Transmission_Oil_Check { get; set; }
        public int? Electrical_Connections_Joints_Check { get; set; }
        public int send_to { get; set; }
        public string flag { get; set; }
    }
    public class JobCartParameters
    {
        public int Garageid { get; set; }
        public int custid { get; set; }
        public int JonCartId { get; set; }
        public string flag { get; set; }
        public int Logid { get; set; }
    }

    public class SendEmail
    {
        public string sEmailid { get; set; }
        public string sName { get; set; }
        public string sPassword { get; set; }
    }

    public class tblRatings
    {
        public int RatingId { get; set; }
        public int? NoofRatings { get; set; }
        public string Review { get; set; }
        public int? Custid { get; set; }
        public int? GarageId { get; set; }
    }

    public class tblfavourite
    {
        public int id { get; set; }
        public int CustId { get; set; }
        public int GaragId { get; set; }
        public bool? isFavourite { get; set; }
        public string flag { get; set; }
    }

    public class GEtlocation
    {
        public float garage_longitude { get; set; }
        public float @garage_latitude { get; set; }
        public int GaragId { get; set; }
        public int addedby { get; set; }
        public string flag { get; set; }
    }
    public partial class Orders
    {
        public int idOrder { get; set; }
        public int idUser { get; set; }
        public int idGarage { get; set; }
        public int vehicleType { get; set; }
        public int Brand { get; set; }
        public int OrderStatus { get; set; }
        public string Notes { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? ServiceDate { get; set; }
        public string VehicleNumber { get; set; }
        public int IsPickUp { get; set; }
        public string flag { get; set; }
        public int TimeSlovet { get; set; }
        public int type { get; set; }
    }
    public class PickupandDrop
    {
        public int id { get; set; }
        public int GarageId { get; set; }
        public string PDtyp { get; set; }
        public string No_slovt { get; set; }
        public string GTime { get; set; }
        public string flag { get; set; }
    }
    public class TImeSlovet
    {
        public int garegid { get; set; }
        public int Timeslovt { get; set; }
        public string pdFlag { get; set; }
        public int noofdrops { get; set; }
    }
    public class GETOrders
    {
        public int idOrder { get; set; }
        public int idUser { get; set; }
        public int idGarage { get; set; }
        public string flag { get; set; }
    }
    public class GETJobDetails
    {
        public int idUser { get; set; }
        public int idGarage { get; set; }
        public int idCustomer { get; set; }
        public string flag { get; set; }
    }
    public class JobcartDetails
    {
        public int idUser { get; set; }
        public int idGarage { get; set; }
        public int idCustomer { get; set; }
        public int Logid { get; set; }
        public string flag { get; set; }
    }
    public class SHOTDISTRIBUTERS
    {
        public int ParentId { get; set; }
        public string Shot_Type { get; set; }
        public string UserName { get; set; }
        public decimal Paid_Amount { get; set; }
        public string BC_Cd { get; set; }
        public string prnt_BC_Cd { get; set; }
    }
}