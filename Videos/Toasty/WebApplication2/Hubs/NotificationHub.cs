﻿using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Hubs
{
    public class NotificationHub : Hub
    {
        public void EnviarNotificacionATodos(string notificacion)
        {
            Clients.All.NuevaNotificacion(notificacion);
        }
    }
}