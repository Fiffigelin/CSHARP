namespace Personalregister.Models;

public class Personal
{
  public Guid Id { get; private set; }
  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public decimal SalaryByMonth { get; private set; }

  public Personal(string fname, string lname, decimal salary)
  {
    InputHandler(fname, "First name");
    InputHandler(lname, "Last name");
    SalaryHandler(salary);

    Id = Guid.NewGuid();
    FirstName = fname;
    LastName = lname;
    SalaryByMonth = salary;
  }

  public string GetFullname()
  {
    return $"{FirstName} {LastName}";
  }

  public void ChangeFirstName(string input)
  {
    InputHandler(input, "First name");
    FirstName = input;
  }
  public void ChangeLastName(string input)
  {
    InputHandler(input, "Last name");
    LastName = input;
  }
  public void ChangeSalary(decimal input)
  {
    SalaryHandler(input);
    SalaryByMonth = input;
  }

  private void InputHandler(string value, string variable)
  {
    if (string.IsNullOrWhiteSpace(value))
    {
      throw new ArgumentException($"{variable} can't be null");
    }
  }

  private void SalaryHandler(decimal input)
  {
    if (input <= 0)
    {
      throw new ArgumentException("The monthly salary can not be 0 or less");
    }
  }
}
