internal interface IShipmentService {
  ShippingFormValidationResult ValidateShippingForm(ShipmentAddress form);
  bool SaveShippingInfo(ShipmentAddress form);
}
