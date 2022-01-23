namespace ServiceAccountingBL.Interfaces
{
    public interface IMapper<FromDto, ToDto>
        where FromDto: class
        where ToDto: class
    {
        ToDto Map(FromDto dto);
    }
}
