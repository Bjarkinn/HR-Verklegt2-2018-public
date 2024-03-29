using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class PaymentDetailRepo {
        private DataContext _db;

        public PaymentDetailRepo() {
            _db = new DataContext();
        }
        public List<PaymentDetailListViewModel> getPaymentDetail(int pdid) {
            var paymentDetail = (from pd in _db.PaymentDetails
                                where pd.Id == pdid
                                select new PaymentDetailListViewModel {
                                Id = pd.Id,
                                AddressId = pd.AddressId,
                                CVC = pd.CVC,
                                CardNumber = pd.CardNumber,
                                ExpiryDate = pd.ExpiryDate,
                                NameOnCard = pd.NameOnCard,
                                UserId = pd.UserId
                                }).ToList();
            return paymentDetail;
        }

        // Spurning hvort við þurfum eitthvertíman að sækja öll payment details?
        public List<PaymentDetailListViewModel> getAllPaymentDetail() {
            var paymentDetail = (from pd in _db.PaymentDetails
                                select new PaymentDetailListViewModel {
                                Id = pd.Id,
                                AddressId = pd.AddressId,
                                CVC = pd.CVC,
                                CardNumber = pd.CardNumber,
                                ExpiryDate = pd.ExpiryDate,
                                NameOnCard = pd.NameOnCard,
                                UserId = pd.UserId
                                }).ToList();
            return paymentDetail;
        }
        public bool updatePaymentDetail(int pdid) {
            // linq update
            return true;
        }
        public bool deletePaymentDetail(int pdid) {
            // linq delete
            return true;
        }
        public int createPaymentDetail(PaymentDetail paymentDetail) {
            _db.PaymentDetails.Add(paymentDetail);
            _db.SaveChanges();
            return paymentDetail.Id;
        }
    }
}