using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Dal.DTO;
using Explorer_GED_V1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Explorer_GED_V1.Dal.Implementations
{
    public class PaymentDal : IPaymentDal
    {
        private readonly ExplorerContext _explorerContext;
        public PaymentDal(ExplorerContext explorerContext)
        {
            _explorerContext = explorerContext;
        }
        public List<PaymentModel> GetPendingPayments()
        {
            var payments = _explorerContext.Payments.ToList();
            var users = _explorerContext.Users.ToList();
            var ids = new List<Guid>();
            var list = new List<PaymentModel>();
            for (int i = 0; i < payments.Count; i++)
            {
                var userTypeId = _explorerContext.Agents.Where(x => x.AgentId == payments[i].AgentId).FirstOrDefault().UserTypeId;
                // list.Add(); 
                var payment = new PaymentModel()
                {
                    CardExpiryDate = payments[i].CardExpiryDate,
                    CardNumber = payments[i].CardNumber,
                    PaymentMethod = payments[i].PaymentMethod,
                    CVV = payments[i].Cvv,
                    PaymentDate = (DateTime)payments[i].PaymentDate,
                    PaymentId = payments[i].PaymentId,
                    NameOnCard = payments[i].NameOnCard,
                    PaymentAmount = payments[i].PaymentAmount,
                    PaymentReference = payments[i].PaymentReference,
                    PaymentStatus = payments[i].PaymentStatus,
                    Photo = payments[i].Photo,
                    PaymentApprovalDate = (DateTime)payments[i].PaymentApprovalDate,
                    PaymentPrintingDate = (DateTime)payments[i].PaymentPrintingDate,
                    CollectionPlace = payments[i].CollectionPlace,
                    CellulairePayment = payments[i].CellulairePayment,
                    PaymentComment = payments[i].PaymentComment,
                    Document = new DocumentModel()
                    {
                        DocumentDescription = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentDescription,
                        DocumentId = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentId,
                        DocumentName = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentName,
                        DocumentPhoto = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentPhoto,
                        DocumentPrice = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentPrice,
                        DocumentType = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentType,
                    },
                    Father = new FatherModel()
                    {
                        Dob = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Dob,
                        FatherId = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().FatherId,
                        Firstname = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Firstname,
                        Name = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Name,
                        FatherProvince = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Province,
                        Surname = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Surname,
                        Town = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Town,
                    },
                    Mother = new MotherModel()
                    {
                        Dob = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Dob,
                        Firstname = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Firstname,
                        MotherId = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().MotherId,
                        Name = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Name,
                        MotherProvince = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Province,
                        Surname = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Surname,
                        Town = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Town,
                    },
                    User = new UserModel()
                    {
                        Dob = (DateTime)_explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Dob,
                        Commune = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Commune,
                        Name = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Name,
                        PostName = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().PostName,
                        Province = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Province,
                        Quartier = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Quartier,
                        streetName = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().StreetName,
                        StreetNumber = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().StreetNumber,
                        Surname = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Surname,
                        Town = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Town,
                        UserId = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().UserId,
                    }
                };
                list.Add(payment);
            }
            return list;
        }

        public bool UpdatePayment(string docStatus, Guid paymentId, string comment)
        {
            var paymentDto = _explorerContext.Payments.Where(x => x.PaymentId == paymentId).FirstOrDefault();
            if (docStatus == "Approved")
            {
                paymentDto.PaymentStatus = docStatus;
                paymentDto.PaymentApprovalDate = DateTime.Now;
                _explorerContext.SaveChanges();
            }

            if (docStatus == "Printed")
            {
                paymentDto.PaymentStatus = docStatus;
                paymentDto.PaymentPrintingDate = DateTime.Now;
            }

            if(docStatus == "Cancel")
            {
                paymentDto.PaymentStatus = docStatus;
                paymentDto.PaymentComment = comment;
                paymentDto.PaymentPrintingDate = DateTime.Now;
            }

            _explorerContext.SaveChanges();
            return true;
        }

        public bool CreatePayment(PaymentModel request)
        {
            Random r = new Random();
            int rInt = r.Next(0, 100);

            var fatherId = Guid.NewGuid();
            var fatherDto = new Father()
            {
                Dob = request.Father.Dob,
                FatherId = fatherId,
                Firstname = request.Father.Firstname,
                Name = request.Father.Name,
                Province = request.Father.FatherProvince,
                Surname = request.Father.Surname,
                Town = request.Father.Town
            };

            _explorerContext.Fathers.Add(fatherDto);
            _explorerContext.SaveChanges();

            var motherId = Guid.NewGuid();
            var motherDto = new Mother()
            {
                Dob = request.Mother.Dob,
                MotherId = motherId,
                Firstname = request.Mother.Firstname,
                Name = request.Mother.Name,
                Province = request.Mother.MotherProvince,
                Surname = request.Mother.Surname,
                Town = request.Mother.Town
            };

            _explorerContext.Mothers.Add(motherDto);
            _explorerContext.SaveChanges();

            var userId = Guid.NewGuid();
            var userDto = new User()
            {
                Commune = request.User.Commune,
                Dob = request.User.Dob,
                Name = request.User.Name,
                PostName = request.User.PostName,
                Province = request.User.Province,
                Quartier = request.User.Quartier,
                StreetName = request.User.streetName,
                StreetNumber = request.User.StreetNumber,
                Surname = request.User.Surname,
                Town = request.User.Town,
                UserId = userId
            };

            _explorerContext.Users.Add(userDto);
            _explorerContext.SaveChanges();

            var paymentDto = new Payment()
            {
                NameOnCard = request.NameOnCard,
                PaymentAmount = request.PaymentAmount,
                PaymentApprovalDate = DateTime.MaxValue,
                PaymentComment = request.PaymentComment,
                CardExpiryDate = request.CardExpiryDate,
                CardNumber = request.CardNumber,
                CellulairePayment = request.CellulairePayment,
                Cvv = request.CardNumber,
                PaymentDate = DateTime.Now,
                PaymentMethod = request.PaymentMethod,
                PaymentPrintingDate = DateTime.MaxValue,
                PaymentReference = rInt.ToString(),
                PaymentStatus = request.PaymentStatus,
                Photo = "Null", //request.Photo,
                CollectionPlace = request.CollectionPlace,
                UserId = userId,
                PaymentId = Guid.NewGuid(),
                AgentId = request.User.UserId,
                DocumentId = request.Document.DocumentId,
                FatherId = fatherId,
                MotherId = motherId
            };
            _explorerContext.Payments.Add(paymentDto);
            _explorerContext.SaveChanges();
            return true;
        }

        public List<PaymentModel> GetPaymentsByUser(Guid agentId)
        {
            var payments = _explorerContext.Payments.Where(x => x.AgentId == agentId).ToList();
            var list = new List<PaymentModel>();
            for (int i = 0; i < payments.Count; i++)
            {
                var userTypeId = _explorerContext.Agents.Where(x => x.AgentId == payments[i].AgentId).FirstOrDefault().UserTypeId;
                var payment = new PaymentModel()
                {
                    CardExpiryDate = payments[i].CardExpiryDate,
                    CardNumber = payments[i].CardNumber,
                    PaymentMethod = payments[i].PaymentMethod,
                    CVV = payments[i].Cvv,
                    PaymentDate = payments[i].PaymentDate,
                    PaymentId = payments[i].PaymentId,
                    NameOnCard = payments[i].NameOnCard,
                    PaymentAmount = payments[i].PaymentAmount,
                    PaymentReference = payments[i].PaymentReference,
                    PaymentStatus = payments[i].PaymentStatus,
                    Photo = payments[i].Photo,
                    PaymentApprovalDate = (DateTime)payments[i].PaymentApprovalDate,
                    PaymentPrintingDate = (DateTime)payments[i].PaymentPrintingDate,
                    CollectionPlace = payments[i].CollectionPlace,
                    CellulairePayment = payments[i].CellulairePayment,
                    User = new UserModel()
                    {
                        Dob = (DateTime)_explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Dob,
                        Commune = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Commune,
                        Name = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Name,
                        PostName = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().PostName,
                        Province = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Province,
                        Quartier = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Quartier,
                        streetName = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().StreetName,
                        StreetNumber = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().StreetNumber,
                        Surname = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Surname,
                        Town = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().Town,
                        UserId = _explorerContext.Users.Where(x => x.UserId == payments[i].UserId).FirstOrDefault().UserId,
                    },
                    Document = new DocumentModel()
                    {
                        DocumentDescription = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentDescription,
                        DocumentId = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentId,
                        DocumentName = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentName,
                        DocumentPhoto = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentPhoto,
                        DocumentPrice = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentPrice,
                        DocumentType = _explorerContext.Documents.Where(x => x.DocumentId == payments[i].DocumentId).FirstOrDefault().DocumentType,
                    },
                    Father = new FatherModel()
                    {
                        Dob = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Dob,
                        FatherId = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().FatherId,
                        Firstname = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Firstname,
                        Name = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Name,
                        FatherProvince = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Province,
                        Surname = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Surname,
                        Town = _explorerContext.Fathers.Where(x => x.FatherId == payments[i].FatherId).FirstOrDefault().Town,
                    },
                    Mother = new MotherModel()
                    {
                        Dob = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Dob,
                        Firstname = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Firstname,
                        MotherId = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().MotherId,
                        Name = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Name,
                        MotherProvince = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Province,
                        Surname = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Surname,
                        Town = _explorerContext.Mothers.Where(x => x.MotherId == payments[i].MotherId).FirstOrDefault().Town,
                    }
                };
                list.Add(payment);
            }
            return list;
        }

        public PaymentModel GetPaymentsByReference(string paymentRef)
        {
            var paymentDto = _explorerContext.Payments.Where(x => x.PaymentReference == paymentRef).FirstOrDefault();
            var userTypeId = _explorerContext.Agents.Where(x => x.AgentId == paymentDto.AgentId).FirstOrDefault().UserTypeId;
            var payment = new PaymentModel()
            {
                CardExpiryDate = paymentDto.CardExpiryDate,
                CardNumber = paymentDto.CardNumber,
                PaymentMethod = paymentDto.PaymentMethod,
                CVV = paymentDto.Cvv,
                PaymentDate = (DateTime)paymentDto.PaymentDate,
                PaymentId = paymentDto.PaymentId,
                NameOnCard = paymentDto.NameOnCard,
                PaymentAmount = paymentDto.PaymentAmount,
                PaymentReference = paymentDto.PaymentReference,
                PaymentStatus = paymentDto.PaymentStatus,
                Photo = paymentDto.Photo,
                PaymentApprovalDate = (DateTime)paymentDto.PaymentApprovalDate,
                PaymentPrintingDate = (DateTime)paymentDto.PaymentPrintingDate,
                CollectionPlace = paymentDto.CollectionPlace,
                CellulairePayment = paymentDto.CellulairePayment,
                User = new UserModel()
                {
                    Dob = (DateTime)_explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Dob,
                    Commune = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Commune,
                    Name = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Name,
                    PostName = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().PostName,
                    Province = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Province,
                    Quartier = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Quartier,
                    streetName = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().StreetName,
                    StreetNumber = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().StreetNumber,
                    Surname = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Surname,
                    Town = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().Town,
                    UserId = _explorerContext.Users.Where(x => x.UserId == paymentDto.UserId).FirstOrDefault().UserId,
                },
                Document = new DocumentModel()
                {
                    DocumentDescription = _explorerContext.Documents.Where(x => x.DocumentId == paymentDto.DocumentId).FirstOrDefault().DocumentDescription,
                    DocumentId = _explorerContext.Documents.Where(x => x.DocumentId == paymentDto.DocumentId).FirstOrDefault().DocumentId,
                    DocumentName = _explorerContext.Documents.Where(x => x.DocumentId == paymentDto.DocumentId).FirstOrDefault().DocumentName,
                    DocumentPhoto = _explorerContext.Documents.Where(x => x.DocumentId == paymentDto.DocumentId).FirstOrDefault().DocumentPhoto,
                    DocumentPrice = _explorerContext.Documents.Where(x => x.DocumentId == paymentDto.DocumentId).FirstOrDefault().DocumentPrice,
                    DocumentType = _explorerContext.Documents.Where(x => x.DocumentId == paymentDto.DocumentId).FirstOrDefault().DocumentType,
                },
                Father = new FatherModel()
                {
                    Dob = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().Dob,
                    FatherId = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().FatherId,
                    Firstname = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().Firstname,
                    Name = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().Name,
                    FatherProvince = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().Province,
                    Surname = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().Surname,
                    Town = _explorerContext.Fathers.Where(x => x.FatherId == paymentDto.FatherId).FirstOrDefault().Town,
                },
                Mother = new MotherModel()
                {
                    Dob = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().Dob,
                    Firstname = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().Firstname,
                    MotherId = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().MotherId,
                    Name = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().Name,
                    MotherProvince = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().Province,
                    Surname = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().Surname,
                    Town = _explorerContext.Mothers.Where(x => x.MotherId == paymentDto.MotherId).FirstOrDefault().Town,
                }
            };
            return payment;
        }
    }
}
