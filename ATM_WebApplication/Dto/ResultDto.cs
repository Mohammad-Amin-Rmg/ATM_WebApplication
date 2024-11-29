namespace ATM_WebApplication.Dto;
public class ResultDto
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}

public class ResultDto<TData>
{
    public TData? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}

