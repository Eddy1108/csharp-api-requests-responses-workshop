namespace workshop.wwwapi.Models.DTO
{
    public class DoublePayload<T1, T2> where T1 : class where T2 : class
    {
        public T1 dataOne { get; set; }
        public T2 dataTwo { get; set; }
    }
}
