﻿namespace webApi_Turismo.models.mododelsdb
{
    public class formasPagoModel
    {
        String idformapago;
        String metodopago;
        String descripcion;
        Boolean estado;
        public string Idformapago { get => idformapago; set => idformapago = value; }
        public string Metodopago { get => metodopago; set => metodopago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
