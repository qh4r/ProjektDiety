using DietyCommonTypes.Extensions;

namespace DietyCommonTypes.Enums
{
    public enum UnitTypes
    {
        
		[UnitTypeValueModyfier(0.001)]
        g,      //gram
		[UnitTypeValueModyfier(1.0)]
        kg,     //kilogram
		[UnitTypeValueModyfier(0.1)]
        dag,    //dekagram
		[UnitTypeValueModyfier(0.2)]
        pcs,    //piece
		[UnitTypeValueModyfier(0.33)]
        cups,
		[UnitTypeValueModyfier(1)]
        l,      //liter
		[UnitTypeValueModyfier(0.001)]
        ml,     //mililiter
		[UnitTypeValueModyfier(0.5)]
        pkg,    //package
		[UnitTypeValueModyfier(0.33)]
        can,
		[UnitTypeValueModyfier(0.2)]
        oz,     //ounce
		[UnitTypeValueModyfier(1.3)]
        lb,     //pound\
		[UnitTypeValueModyfier(0.01)]
        teaspoon,
		[UnitTypeValueModyfier(0.02)]
        tablespoon,
		[UnitTypeValueModyfier(0.005)]
        pinch,  //szczypta

        
    }
}
