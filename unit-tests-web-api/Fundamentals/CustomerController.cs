namespace unit_tests_nunit;

public class CustomerController
{
    public ActionResult GetCustomer(int id)
    {
        if (id == 0)
            return new NotFound();
            
        return new Ok();
    }        
}
    
public class ActionResult { }
    
public class NotFound : ActionResult { }
 
public class Ok : ActionResult { }