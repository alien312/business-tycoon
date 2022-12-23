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
	public const int BusinessId = 0;
    public const int IncomeProgress = 1;
    public const int IncomeValue = 2;
    public const int Level = 3;
    public const int Settings = 4;

	public static readonly string[] Names =
	{
		"BusinessId",
        "IncomeProgress",
        "IncomeValue",
        "Level",
        "Settings"
	};
	
	public static readonly System.Type[] Types = 
	{
		typeof(BusinessIdComponent),
        typeof(IncomeProgressComponent),
        typeof(IncomeValueComponent),
        typeof(LevelComponent),
        typeof(SettingsComponent)
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