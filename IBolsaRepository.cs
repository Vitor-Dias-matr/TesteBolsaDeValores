using System;

public class IBolsaRepository
{
	public interface IBolsaRepository
	{
        IList<Portfolio> Query();

    }
}
