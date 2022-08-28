using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulam sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection çalışma anında çalıştırmaya yarıyor.(instance oluştur)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //_validatorType base tpype'nı bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //metotun parametlerine bak
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //ValidationTool'u kullanarak validate et
            }
        }
    }
}
