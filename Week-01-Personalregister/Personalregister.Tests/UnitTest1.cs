using Personalregister.Models;

namespace Personalregister.Tests;

public class UnitTest1
{
  [Fact]
  public void CanCreatePersonal()
  {
    var personal = new Personal("Kalle", "Anka", 18000);

    Assert.Equal("Kalle", personal.FirstName);
    Assert.Equal("Anka", personal.LastName);
    Assert.Equal(18000, personal.SalaryByMonth);
  }
}
