namespace WeirdCounting
{
  public class RowWithNumber
  {
    public int RowNum { get; set; }
    public string Data { get; set; }

    public override string ToString()
    {
      return $"{RowNum}\t{Data}";
    }
  }
}