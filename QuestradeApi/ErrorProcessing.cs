﻿namespace QuestradeApi
{
    public enum ErrorType { General, Order}
    public class GeneralErrorResp
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class OrderProcesssingErrorResp : GeneralErrorResp
    {
        public int orderId { get; set; }
        public Orders orders;
    }
}