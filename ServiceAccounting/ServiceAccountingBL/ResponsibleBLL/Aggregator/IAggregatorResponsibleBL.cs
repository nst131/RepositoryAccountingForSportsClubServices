using ServiceAccountingBL.ResponsibleBLL.Crud;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingBL.ResponsibleBLL.Validation;

namespace ServiceAccountingBL.ResponsibleBLL.Aggregator
{
    public interface IAggregatorResponsibleBL
    {
        IResponsibleCrudBL ResponsibleCrudBL { get; }
        IResponsibleValidator<CreateResponsibleDtoBL> CreateResponsibleValidator { get; }
        IResponsibleValidator<UpdateResponsibleDtoBL> UpdateResponsibleValidator { get; }
    }
}