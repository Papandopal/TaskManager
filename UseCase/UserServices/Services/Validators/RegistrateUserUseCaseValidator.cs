using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.Database;
using UseCase.UserServices.Services.DTOs;

namespace UseCase.UserServices.Services.Validators
{
    public class RegistrateUserUseCaseValidator : AbstractValidator<RegistrateUserUseCaseDTO>
    {
        public RegistrateUserUseCaseValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(x => x.Email).Must(email =>
            {
                return !unitOfWork.UserRepository.IsExistsByEmail(email);
            }).WithMessage("this email already in use");
        }
    }
}
