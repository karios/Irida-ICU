using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICU
{
        /// <summary>
        /// Singleton Wrapper. Store the connected ivus. 
        /// </summary>
        public sealed class IvuDB
        {
            private static readonly IvuDB instance = new IvuDB();
            private List<IvuInfo> ivus = new List<IvuInfo>();

            private IvuDB() {   
            }

            public static IvuDB Instance
            {
                get
                {
                    return instance;
                }
            }

            /// <summary>
            /// Add an Ivu to the Ivu list.
            /// </summary>
            /// <param name="ivu"></param>

            public void addIvu(IvuInfo ivu)
            {
                this.ivus.Add(ivu);
            }

            /// <summary>
            /// delete an Ivu from the Ivu list.
            /// </summary>
            /// <param name="ivu"></param>
            public void delIvu(IvuInfo ivu)
            {
                this.ivus.Remove(ivu);
            }


            /// <summary>
            /// Check if the ivu exist already.
            /// </summary>
            /// <param name="ivu"></param>
            public Boolean exists(IvuInfo ivu)
            {
                foreach (IvuInfo eivu in this.ivus)
                {
                    if (eivu.Equals(ivu)) return true;

                }

                return false;
            }

            /// <summary>
            /// Return the Ivu values (to iterate).
            /// </summary>
            /// <returns></returns>
            public List<IvuInfo> values()
            {
                return this.ivus;

            }

            /// <summary>
            /// Return the number of connected Ivus.
            /// </summary>
            /// <returns></returns>
            public int count()
            {
                return this.ivus.Count;
            }



        }

}
