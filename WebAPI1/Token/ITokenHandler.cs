namespace WebAPI1.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute);
    }
}
