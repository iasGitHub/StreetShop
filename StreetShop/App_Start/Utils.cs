﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionStock.App_Start
{
    public class Utils
    {
    }

    //Tableau "enum" contenant lesclasses de bootstrap
    public enum FlashLevel
    {
        Info = 1,
        Success = 2,
        Warning = 3,
        Danger = 4
    }

    //la méthode Flashelper récupère le controller ds lequel le msg est envoyé
    public static class FlashHelper
    {
        public static void Flash(this Controller controller, string message, FlashLevel level)
        {
            IList<string> messages = null;
            string key = String.Format("flash-{0}", level.ToString().ToLower());

            messages = (controller.TempData.ContainsKey(key))
                ? (IList<string>)controller.TempData[key]
                : new List<string>();

            messages.Add(message);

            controller.TempData[key] = messages;
        }
    }

}