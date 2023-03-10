using NanoEcs; 
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class ActiveComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public bool IsActive 
	{
	get
        {
            return Has(GameComponentsMap.Active);
        }
        set
        {
            if (value)
            {
                Add<ActiveComponent>(GameComponentsMap.Active);
            } else
            {
                RemoveComponentOfIndex(GameComponentsMap.Active);
            }
        }
	}
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Active
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Active);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Active
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Active);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Active
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Active);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class BalanceComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public BalanceComponent Balance
	{
        get
        {
            if (!Has(GameComponentsMap.Balance))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<BalanceComponent>(GameComponentsMap.Balance);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddBalance (float value)
	{
		var c = Add<BalanceComponent>(GameComponentsMap.Balance);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddBalance (float value)
	{
		BalanceComponent c;
        if (HasBalance)
        {
            c = Balance;
        } else
        {
            c = Add<BalanceComponent>(GameComponentsMap.Balance);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveBalance ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.Balance);
		return this;
	}
	
	public bool HasBalance 
	{
			get 
			{
				return Has(GameComponentsMap.Balance);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Balance
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Balance);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Balance
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Balance);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Balance
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Balance);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class BaseIncomeTimeComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public BaseIncomeTimeComponent BaseIncomeTime
	{
        get
        {
            if (!Has(GameComponentsMap.BaseIncomeTime))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<BaseIncomeTimeComponent>(GameComponentsMap.BaseIncomeTime);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddBaseIncomeTime (float value)
	{
		var c = Add<BaseIncomeTimeComponent>(GameComponentsMap.BaseIncomeTime);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddBaseIncomeTime (float value)
	{
		BaseIncomeTimeComponent c;
        if (HasBaseIncomeTime)
        {
            c = BaseIncomeTime;
        } else
        {
            c = Add<BaseIncomeTimeComponent>(GameComponentsMap.BaseIncomeTime);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveBaseIncomeTime ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.BaseIncomeTime);
		return this;
	}
	
	public bool HasBaseIncomeTime 
	{
			get 
			{
				return Has(GameComponentsMap.BaseIncomeTime);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup BaseIncomeTime
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.BaseIncomeTime);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup BaseIncomeTime
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.BaseIncomeTime);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup BaseIncomeTime
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.BaseIncomeTime);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class BusinessIdComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public BusinessIdComponent BusinessId
	{
        get
        {
            if (!Has(GameComponentsMap.BusinessId))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<BusinessIdComponent>(GameComponentsMap.BusinessId);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddBusinessId (string value)
	{
		var c = Add<BusinessIdComponent>(GameComponentsMap.BusinessId);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddBusinessId (string value)
	{
		BusinessIdComponent c;
        if (HasBusinessId)
        {
            c = BusinessId;
        } else
        {
            c = Add<BusinessIdComponent>(GameComponentsMap.BusinessId);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveBusinessId ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.BusinessId);
		return this;
	}
	
	public bool HasBusinessId 
	{
			get 
			{
				return Has(GameComponentsMap.BusinessId);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup BusinessId
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.BusinessId);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup BusinessId
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.BusinessId);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup BusinessId
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.BusinessId);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class CostComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public CostComponent Cost
	{
        get
        {
            if (!Has(GameComponentsMap.Cost))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<CostComponent>(GameComponentsMap.Cost);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddCost (float value)
	{
		var c = Add<CostComponent>(GameComponentsMap.Cost);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddCost (float value)
	{
		CostComponent c;
        if (HasCost)
        {
            c = Cost;
        } else
        {
            c = Add<CostComponent>(GameComponentsMap.Cost);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveCost ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.Cost);
		return this;
	}
	
	public bool HasCost 
	{
			get 
			{
				return Has(GameComponentsMap.Cost);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Cost
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Cost);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Cost
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Cost);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Cost
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Cost);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class IncomeProgressComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public IncomeProgressComponent IncomeProgress
	{
        get
        {
            if (!Has(GameComponentsMap.IncomeProgress))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<IncomeProgressComponent>(GameComponentsMap.IncomeProgress);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddIncomeProgress (float value)
	{
		var c = Add<IncomeProgressComponent>(GameComponentsMap.IncomeProgress);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddIncomeProgress (float value)
	{
		IncomeProgressComponent c;
        if (HasIncomeProgress)
        {
            c = IncomeProgress;
        } else
        {
            c = Add<IncomeProgressComponent>(GameComponentsMap.IncomeProgress);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveIncomeProgress ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.IncomeProgress);
		return this;
	}
	
	public bool HasIncomeProgress 
	{
			get 
			{
				return Has(GameComponentsMap.IncomeProgress);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup IncomeProgress
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.IncomeProgress);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup IncomeProgress
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.IncomeProgress);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup IncomeProgress
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.IncomeProgress);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class IncomeValueComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public IncomeValueComponent IncomeValue
	{
        get
        {
            if (!Has(GameComponentsMap.IncomeValue))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<IncomeValueComponent>(GameComponentsMap.IncomeValue);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddIncomeValue (float value)
	{
		var c = Add<IncomeValueComponent>(GameComponentsMap.IncomeValue);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddIncomeValue (float value)
	{
		IncomeValueComponent c;
        if (HasIncomeValue)
        {
            c = IncomeValue;
        } else
        {
            c = Add<IncomeValueComponent>(GameComponentsMap.IncomeValue);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveIncomeValue ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.IncomeValue);
		return this;
	}
	
	public bool HasIncomeValue 
	{
			get 
			{
				return Has(GameComponentsMap.IncomeValue);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup IncomeValue
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.IncomeValue);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup IncomeValue
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.IncomeValue);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup IncomeValue
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.IncomeValue);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class IncreaseIncomeModifierComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public IncreaseIncomeModifierComponent IncreaseIncomeModifier
	{
        get
        {
            if (!Has(GameComponentsMap.IncreaseIncomeModifier))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<IncreaseIncomeModifierComponent>(GameComponentsMap.IncreaseIncomeModifier);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddIncreaseIncomeModifier (float value)
	{
		var c = Add<IncreaseIncomeModifierComponent>(GameComponentsMap.IncreaseIncomeModifier);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddIncreaseIncomeModifier (float value)
	{
		IncreaseIncomeModifierComponent c;
        if (HasIncreaseIncomeModifier)
        {
            c = IncreaseIncomeModifier;
        } else
        {
            c = Add<IncreaseIncomeModifierComponent>(GameComponentsMap.IncreaseIncomeModifier);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveIncreaseIncomeModifier ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.IncreaseIncomeModifier);
		return this;
	}
	
	public bool HasIncreaseIncomeModifier 
	{
			get 
			{
				return Has(GameComponentsMap.IncreaseIncomeModifier);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup IncreaseIncomeModifier
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.IncreaseIncomeModifier);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup IncreaseIncomeModifier
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.IncreaseIncomeModifier);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup IncreaseIncomeModifier
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.IncreaseIncomeModifier);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class LevelComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public LevelComponent Level
	{
        get
        {
            if (!Has(GameComponentsMap.Level))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<LevelComponent>(GameComponentsMap.Level);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddLevel (int value)
	{
		var c = Add<LevelComponent>(GameComponentsMap.Level);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddLevel (int value)
	{
		LevelComponent c;
        if (HasLevel)
        {
            c = Level;
        } else
        {
            c = Add<LevelComponent>(GameComponentsMap.Level);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveLevel ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.Level);
		return this;
	}
	
	public bool HasLevel 
	{
			get 
			{
				return Has(GameComponentsMap.Level);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Level
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Level);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Level
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Level);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Level
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Level);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class ModifierComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public ModifierComponent Modifier
	{
        get
        {
            if (!Has(GameComponentsMap.Modifier))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<ModifierComponent>(GameComponentsMap.Modifier);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddModifier (object type)
	{
		var c = Add<ModifierComponent>(GameComponentsMap.Modifier);
		c.Type = type;
		return this;
	}
	
	public GameEntity SafelyAddModifier (object type)
	{
		ModifierComponent c;
        if (HasModifier)
        {
            c = Modifier;
        } else
        {
            c = Add<ModifierComponent>(GameComponentsMap.Modifier);
        }
        c.Type = type;
        return this;
	}
	
	public GameEntity RemoveModifier ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.Modifier);
		return this;
	}
	
	public bool HasModifier 
	{
			get 
			{
				return Has(GameComponentsMap.Modifier);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Modifier
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Modifier);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Modifier
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Modifier);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Modifier
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Modifier);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class ReduceIncomeTimeModifierComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public ReduceIncomeTimeModifierComponent ReduceIncomeTimeModifier
	{
        get
        {
            if (!Has(GameComponentsMap.ReduceIncomeTimeModifier))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<ReduceIncomeTimeModifierComponent>(GameComponentsMap.ReduceIncomeTimeModifier);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddReduceIncomeTimeModifier (float value)
	{
		var c = Add<ReduceIncomeTimeModifierComponent>(GameComponentsMap.ReduceIncomeTimeModifier);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddReduceIncomeTimeModifier (float value)
	{
		ReduceIncomeTimeModifierComponent c;
        if (HasReduceIncomeTimeModifier)
        {
            c = ReduceIncomeTimeModifier;
        } else
        {
            c = Add<ReduceIncomeTimeModifierComponent>(GameComponentsMap.ReduceIncomeTimeModifier);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveReduceIncomeTimeModifier ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.ReduceIncomeTimeModifier);
		return this;
	}
	
	public bool HasReduceIncomeTimeModifier 
	{
			get 
			{
				return Has(GameComponentsMap.ReduceIncomeTimeModifier);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup ReduceIncomeTimeModifier
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.ReduceIncomeTimeModifier);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup ReduceIncomeTimeModifier
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.ReduceIncomeTimeModifier);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup ReduceIncomeTimeModifier
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.ReduceIncomeTimeModifier);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class SettingsComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public SettingsComponent Settings
	{
        get
        {
            if (!Has(GameComponentsMap.Settings))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<SettingsComponent>(GameComponentsMap.Settings);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddSettings (object value)
	{
		var c = Add<SettingsComponent>(GameComponentsMap.Settings);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddSettings (object value)
	{
		SettingsComponent c;
        if (HasSettings)
        {
            c = Settings;
        } else
        {
            c = Add<SettingsComponent>(GameComponentsMap.Settings);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveSettings ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.Settings);
		return this;
	}
	
	public bool HasSettings 
	{
			get 
			{
				return Has(GameComponentsMap.Settings);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Settings
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Settings);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Settings
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Settings);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Settings
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Settings);
            return group as GameGroup;
        }
    }
}
//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a NanoECS.Generator. 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------


public partial class TargetComponent : ComponentEcs 
{
}
public partial class GameEntity 
{
	public TargetComponent Target
	{
        get
        {
            if (!Has(GameComponentsMap.Target))
            {
				throw new System.Exception("Entity doesn't have an existing component");
            }
            return Get<TargetComponent>(GameComponentsMap.Target);
        }
	}
}
public partial class GameEntity 
{
	public GameEntity AddTarget (GameEntity value)
	{
		var c = Add<TargetComponent>(GameComponentsMap.Target);
		c.Value = value;
		return this;
	}
	
	public GameEntity SafelyAddTarget (GameEntity value)
	{
		TargetComponent c;
        if (HasTarget)
        {
            c = Target;
        } else
        {
            c = Add<TargetComponent>(GameComponentsMap.Target);
        }
        c.Value = value;
        return this;
	}
	
	public GameEntity RemoveTarget ()
	{
		
		
		if (IsReserved) throw new System.Exception("Unable to remove component from reserved entity");
		
		RemoveComponentOfIndex(GameComponentsMap.Target);
		return this;
	}
	
	public bool HasTarget 
	{
			get 
			{
				return Has(GameComponentsMap.Target);
			}
	}
	
}
public partial class GameWithBuilder : WithBuilder<GameEntity> 
{
    public GameGroup Target
    {
        get
        {
            group.WithTypes.Add(GameComponentsMap.Target);
            return group as GameGroup;
        }
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{

    public GameGroup Target
    {
        get
        {
            group.WithoutTypes.Add(GameComponentsMap.Target);
            return group as GameGroup;
        }
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameGroup Target
    {
        get
        {
            group.AnyofTypes.Add(GameComponentsMap.Target);
            return group as GameGroup;
        }
    }
}
public partial class GameWithBuilder : WithBuilder<GameEntity>
{
    public GameWithBuilder (Group<GameEntity> group) : base(group)
    {
    }
}

public partial class GameWithoutBuilder : WithoutBuilder<GameEntity>
{
    public GameWithoutBuilder (Group<GameEntity> group) : base(group)
    {
    }
}

public partial class GameAnyofBuilder : AnyofBuilder<GameEntity>
{
    public GameAnyofBuilder (Group<GameEntity> group) : base(group)
    {
    }
}

public partial class GameGroup : Group<GameEntity>
{
	public GameGroup()
	{
	    withBuilder = new GameWithBuilder(this);
        withoutBuilder = new GameWithoutBuilder(this);
        anyofBuilder = new GameAnyofBuilder(this);
	}
	
	public GameCollector OnAdd
    {
        get
        {
            var onAdd = new GameCollector();
            InternalOnAdd(onAdd);
            return onAdd;
        }
    }
	
	public GameCollector OnRemove
    {
        get
        {
            var onRemove = new GameCollector();
            InternalOnRemove(onRemove);
            return onRemove;
        }
    }
	
	public GameCollector OnDestroy
    {
        get
        {
            var onDestroy = new GameCollector();
            InternalOnDestroy(onDestroy);
            return onDestroy;
        }
    }
	
	public GameWithBuilder With
    {
        get { return withBuilder as GameWithBuilder; }
    }

    public GameWithoutBuilder Without
    {
        get { return withoutBuilder as GameWithoutBuilder; }
    }

    public GameAnyofBuilder AnyOf
    {
        get { return anyofBuilder as GameAnyofBuilder; }
    }
}

public partial class GameCollector : Collector<GameEntity>
{
}

public static class GameComponentsMap
{
	public const int Active = 0;
    public const int Balance = 1;
    public const int BaseIncomeTime = 2;
    public const int BusinessId = 3;
    public const int Cost = 4;
    public const int IncomeProgress = 5;
    public const int IncomeValue = 6;
    public const int IncreaseIncomeModifier = 7;
    public const int Level = 8;
    public const int Modifier = 9;
    public const int ReduceIncomeTimeModifier = 10;
    public const int Settings = 11;
    public const int Target = 12;

	public static readonly string[] Names =
	{
		"Active",
        "Balance",
        "BaseIncomeTime",
        "BusinessId",
        "Cost",
        "IncomeProgress",
        "IncomeValue",
        "IncreaseIncomeModifier",
        "Level",
        "Modifier",
        "ReduceIncomeTimeModifier",
        "Settings",
        "Target"
	};
	
	public static readonly System.Type[] Types = 
	{
		typeof(ActiveComponent),
        typeof(BalanceComponent),
        typeof(BaseIncomeTimeComponent),
        typeof(BusinessIdComponent),
        typeof(CostComponent),
        typeof(IncomeProgressComponent),
        typeof(IncomeValueComponent),
        typeof(IncreaseIncomeModifierComponent),
        typeof(LevelComponent),
        typeof(ModifierComponent),
        typeof(ReduceIncomeTimeModifierComponent),
        typeof(SettingsComponent),
        typeof(TargetComponent)
	};
}
public partial class Contexts 
{
	public GameContext Game = new GameContext(GameComponentsMap.Types);
}

public static class GameContextExtensions 
{
	public static GameEntity ToGameEntity(this int id, Contexts contexts) 
	{
		return contexts.Game.GetEntity(id);
	}
}
public partial class GameContext : Context<GameEntity>
{
	
	
	public GameGroup GetGroup()
    {
		return (GameGroup)CreateGroupInternal(new GameGroup());
    }
	
	public GameContext(System.Type[] componentTypes) : base(componentTypes)
    {
    }
}
public partial class GameEntity : Entity
{
}
namespace NanoEcs 
{
	public class Game : System.Attribute 
	{
	}
}