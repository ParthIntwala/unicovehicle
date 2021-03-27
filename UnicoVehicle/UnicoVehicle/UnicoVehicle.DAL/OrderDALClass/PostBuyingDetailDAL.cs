using System;
using UnicoVehicle.Utilities;
using UnicoVehicle.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnicoVehicle.DAL
{
    public class PostBuyingDetailDAL : IPostBuyingDetailDAL
    {
        private readonly Connection _connection;
        private readonly IUtils _utils;
        private SqlCommand _buyingDetailCommand;
        private SqlDataReader _buyingDetailReader;
        int _success;

        public PostBuyingDetailDAL(Connection connection, IUtils utils)
        {
            _connection = connection;
            _utils = utils;
        }

        public PostBuyingDetail GetPostBuyingDetailbyId(int id)
        {
            _buyingDetailCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.GetPostBuyingDetailbyId);
            _buyingDetailCommand.Parameters.AddWithValue("@orderId", id);
            _buyingDetailReader = _buyingDetailCommand.ExecuteReader();

            PostBuyingDetail _buyingDetail = new PostBuyingDetail();

            while (_buyingDetailReader.Read())
            {
                _buyingDetail = new PostBuyingDetail
                {
                    OrderId = id,
                    TaxValidity = Convert.ToDateTime(_buyingDetailReader["TaxValidUpto"].ToString()),
                    InsuranceCompany = new DTO.Miscellaneous.InsuranceCompany
                    {
                        InsuranceCompanyId = int.Parse(_buyingDetailReader["InsuranceCompanyId"].ToString()),
                    },
                    InsuranceType = new InsuranceType
                    {
                        InsuranceTypeId = int.Parse(_buyingDetailReader["InsuranceTypeId"].ToString()),
                    },
                    FreeService = int.Parse(_buyingDetailReader["RemainingFreeService"].ToString()),
                    LoanEMI = double.Parse(_buyingDetailReader["LoanEMI"].ToString()),
                    PostBuyingDetailId = int.Parse(_buyingDetailReader["PostBuyingDetailId"].ToString()),
                    InsurancePremium = double.Parse(_buyingDetailReader["InsurancePremium"].ToString()),
                    InsuranceValidity = Convert.ToDateTime(_buyingDetailReader["InsuranceValidUpto"].ToString()),
                    PaymentReceived = bool.Parse(_buyingDetailReader["PaymentReceived"].ToString()),
                };
            }

            _buyingDetailReader.Close();
            _connection.CloseConnection();

            return _buyingDetail;
        }

        public bool InsertPostBuyingDetail(PostBuyingDetail postBuyingDetail)
        {
            _buyingDetailCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.InsertPostBuyingDetail);
            _buyingDetailCommand.Parameters.AddWithValue("@insuranceCompanyId", postBuyingDetail.InsuranceCompany.InsuranceCompanyId);
            _buyingDetailCommand.Parameters.AddWithValue("@insuranceTypeId", postBuyingDetail.InsuranceType.InsuranceTypeId);
            _buyingDetailCommand.Parameters.AddWithValue("@insuranceValidUpto", postBuyingDetail.InsuranceValidity);
            _buyingDetailCommand.Parameters.AddWithValue("@insurancePremium", postBuyingDetail.InsurancePremium);
            _buyingDetailCommand.Parameters.AddWithValue("@loanEMI", postBuyingDetail.LoanEMI);
            _buyingDetailCommand.Parameters.AddWithValue("@taxValidUpto", postBuyingDetail.TaxValidity);
            _buyingDetailCommand.Parameters.AddWithValue("@paymentReceived", postBuyingDetail.PaymentReceived);
            _buyingDetailCommand.Parameters.AddWithValue("@orderId", postBuyingDetail.OrderId);
            _buyingDetailCommand.Parameters.AddWithValue("@remainingFreeService", postBuyingDetail.FreeService);
            _buyingDetailCommand.Parameters.AddWithValue("@createdDate", DateTime.Now);

            _success = _buyingDetailCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePostBuyingDetail(PostBuyingDetail postBuyingDetail, int id)
        {
            _buyingDetailCommand = _utils.CommandGenerator(ResourceFiles.OrderDALResources.UpdatePostBuyingDetail);
            _buyingDetailCommand.Parameters.AddWithValue("@postBuyingDetailId", id);
            _buyingDetailCommand.Parameters.AddWithValue("@insuranceCompanyId", postBuyingDetail.InsuranceCompany.InsuranceCompanyId);
            _buyingDetailCommand.Parameters.AddWithValue("@insuranceTypeId", postBuyingDetail.InsuranceType.InsuranceTypeId);
            _buyingDetailCommand.Parameters.AddWithValue("@insurancePremium", postBuyingDetail.InsurancePremium);
            _buyingDetailCommand.Parameters.AddWithValue("@taxValidUpto", postBuyingDetail.TaxValidity);
            _buyingDetailCommand.Parameters.AddWithValue("@insuranceValidUpto", postBuyingDetail.InsuranceValidity);
            _buyingDetailCommand.Parameters.AddWithValue("@paymentReceived", postBuyingDetail.PaymentReceived);
            _buyingDetailCommand.Parameters.AddWithValue("@remainingFreeService", postBuyingDetail.FreeService);
            _buyingDetailCommand.Parameters.AddWithValue("@modifiedDate", DateTime.Now);

            _success = _buyingDetailCommand.ExecuteNonQuery();
            _connection.CloseConnection();

            if (_success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
