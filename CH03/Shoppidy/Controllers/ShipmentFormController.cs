﻿using Microsoft.AspNetCore.Mvc;

public enum ShippingFormValidationResult
{
    Valid,
    InvalidName,
    AddressDoesNotExist,
    CityDoesNotExist,
    ZipCodeDidntMatch,
}

public class ShipmentFormController(IShipmentService service) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Submit(ShipmentAddress form)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", "ShippingForm", form);
        }
        var validationResult = service.ValidateShippingForm(form);
        if (validationResult != ShippingFormValidationResult.Valid)
        {
            return RedirectToAction("Index", "ShippingForm", form);
        }
        bool success = service.SaveShippingInfo(form);
        if (!success)
        {
            ModelState.AddModelError("", "Problem occurred while " +
              "saving your information, please try again");
            return RedirectToAction("Index", "ShippingForm", form);
        }
        return RedirectToAction("Index", "BillingForm");
    }

    [HttpPost]
    public IActionResult Submit2(ShipmentAddress form)
    {
        if (!ModelState.IsValid)
        {
            goto Error;
        }
        var validationResult = service.ValidateShippingForm(form);
        if (validationResult != ShippingFormValidationResult.Valid)
        {
            goto Error;
        }
        bool success = service.SaveShippingInfo(form);
        if (!success)
        {
            ModelState.AddModelError("", "Problem occurred while " +
              "saving your information, please try again");
            goto Error;
        }
        return RedirectToAction("Index", "BillingForm");
    Error:
        return RedirectToAction("Index", "ShippingForm", form);
    }

    [HttpPost]
    public IActionResult Submit3(ShipmentAddress form)
    {
        if (!ModelState.IsValid)
        {
            goto Error;
        }
        var validationResult = service.ValidateShippingForm(form);
        if (validationResult != ShippingFormValidationResult.Valid)
        {
            goto Error;
        }
        bool success = service.SaveShippingInfo(form);
        if (!success)
        {
            ModelState.AddModelError("", "Problem occurred while " +
              "saving your information, please try again");
            goto Error;
        }
        return RedirectToAction("Index", "BillingForm");
    Error:
        Response.Cookies.Append("shipping_error", "1");
        return RedirectToAction("Index", "ShippingForm", form);
    }

    [HttpPost]
    public IActionResult Submit4(ShipmentAddress form)
    {
        IActionResult error()
        {
            Response.Cookies.Append("shipping_error", "1");
            return RedirectToAction("Index", "ShippingForm", form);
        }

        if (!ModelState.IsValid)
        {
            return error();
        }
        var validationResult = service.ValidateShippingForm(form);
        if (validationResult != ShippingFormValidationResult.Valid)
        {
            return error();
        }
        bool success = service.SaveShippingInfo(form);
        if (!success)
        {
            ModelState.AddModelError("", "Problem occurred while " +
              "saving your information, please try again");
            return error();
        }
        return RedirectToAction("Index", "BillingForm");
    }

    /*** refactored sample **/

    [HttpPost]
    public IActionResult Submit6(ShipmentAddress form)
    {
        if (!validate(form))
        {
            return shippingFormError();
        }
        bool success = service.SaveShippingInfo(form);
        if (!success)
        {
            reportSaveError();
            return shippingFormError(form);
        }
        return RedirectToAction("Index", "BillingForm");
    }

    private bool validate(ShipmentAddress form)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }
        var validationResult = service.ValidateShippingForm(form);
        return validationResult == ShippingFormValidationResult.Valid;
    }

    private RedirectToActionResult shippingFormError(ShipmentAddress? form = null)
    {
        Response.Cookies.Append("shipping_error", "1");
        return RedirectToAction("Index", "ShippingForm", form);
    }

    private void reportSaveError()
    {
        ModelState.AddModelError("", "Problem occurred while " +
          "saving your information, please try again");
    }

    /*** refactored sample end **/

    /// <summary>
    /// Receive a shipment address model and update it in the 
    /// database and then redirect the user to billing page if 
    /// it's successful.
    /// </summary>
    /// <param name="form">The model to receive.</param>
    /// <returns>Redirect result to the entry form if
    /// there is an error, or redirect result to the
    /// billing form page if successful.</returns>
    [HttpPost]
    public IActionResult Submit5(ShipmentAddress form)
    {
        // Our common error handling code that saves the cookie
        // and redirects back to the entry form for 
        // shipping information.
        IActionResult error()
        {
            Response.Cookies.Append("shipping_error", "1");
            return RedirectToAction("Index", "ShippingForm", form);
        }
        // check if the model state is valid
        if (!ModelState.IsValid)
        {
            return error();
        }
        // validate the form with server side validation logic.
        var validationResult = service.ValidateShippingForm(form);
        // is the validation successful?
        if (validationResult != ShippingFormValidationResult.Valid)
        {
            return error();
        }
        // save shipping information
        bool success = service.SaveShippingInfo(form);
        if (!success)
        {
            // failed to save. report the error to the user.
            ModelState.AddModelError("", "Problem occurred while " +
              "saving your information, please try again");
            return error();
        }
        // go to the billing form
        return RedirectToAction("Index", "BillingForm");
    }


}
