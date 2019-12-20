using System;

namespace LuaScripting
{
    public partial class LuaIndividualDomain : LuaDomain
    {
        /// <summary>
        /// Runs the before update actions of the individual object.
        /// </summary>
        public override void BeforeUpdateActions()
        {
            this.LuaIndividualObject.BeforeUpdateActions();
        }

        /// <summary>
        /// Runs the after late update actions of the individual object.
        /// </summary>
        public override void AfterLateUpdateActions()
        {
            this.LuaIndividualObject.AfterLateUpdateActions();
        }
    }
}
