using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidator
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Girmiş olduğunuz parolalar eşleşmiyor!");
        }
    }
}
