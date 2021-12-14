using ServiceAccountingBL.ResponsibleBLL.Crud;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingBL.ResponsibleBLL.Validation;
using System;

namespace ServiceAccountingBL.ResponsibleBLL.Aggregator
{
    public class AggregatorResponsibleBL : IAggregatorResponsibleBL
    {
        private readonly Lazy<IResponsibleCrudBL> responsibleCrudBL;
        private readonly Lazy<IResponsibleValidator<CreateResponsibleDtoBL>> createResponsibleValidator;
        private readonly Lazy<IResponsibleValidator<UpdateResponsibleDtoBL>> updateResponsibleValidator;

        public AggregatorResponsibleBL(Lazy<IResponsibleCrudBL> responsibleCrudBL,
            Lazy<IResponsibleValidator<CreateResponsibleDtoBL>> createResponsibleValidator,
            Lazy<IResponsibleValidator<UpdateResponsibleDtoBL>> updateResponsibleValidator)
        {
            this.responsibleCrudBL = responsibleCrudBL;
            this.createResponsibleValidator = createResponsibleValidator;
            this.updateResponsibleValidator = updateResponsibleValidator;
        }

        public IResponsibleCrudBL ResponsibleCrudBL => responsibleCrudBL.Value;
        public IResponsibleValidator<CreateResponsibleDtoBL> CreateResponsibleValidator => createResponsibleValidator.Value;
        public IResponsibleValidator<UpdateResponsibleDtoBL> UpdateResponsibleValidator => updateResponsibleValidator.Value;
    }
}
