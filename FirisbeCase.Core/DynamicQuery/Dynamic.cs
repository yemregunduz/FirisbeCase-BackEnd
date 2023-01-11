namespace FirisbeCase.Core.DynamicQuery;
/// <summary>
/// Bu parametre { } şeklinde boş gönderilebilir. Sonuç tüm veri olacaktır.
/// </summary>
public class Dynamic
{
    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }

    public Dynamic()
    {
    }

    public Dynamic(IEnumerable<Sort>? sort, Filter? filter)
    {
        Sort = sort;
        Filter = filter;
    }
}