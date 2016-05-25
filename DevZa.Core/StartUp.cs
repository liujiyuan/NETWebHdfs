using System;
using DevZa.Logger;

namespace DevZa
{
    public static class StartUp
    {


        static StartUp()
        {
            IZaLogger log = LoggerFactory.GetLogger(typeof(StartUp));
            log.Debug(" Core Start up");
            try
            {

            }
            catch (Exception ex)
            {
                log.ErrorParm("init error", ex);
            }
        }
    }

}
