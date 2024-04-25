namespace InfoTrackSeo.API.Validation
{
    public interface IValidate<T>
    {
        void Validate(T model);
    }
}
