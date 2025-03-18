# Blazor Navigation

The project provides a reusable Blazor navigation menu component and a simple Blazor Web Assembly application, just for demonstration. It allows us to create hierarchical menus with unlimited nesting using Bootstrap styling. The projects inside the solution are developed using .NET 9.

## Project structure  ##


**1. BlazorNavigation.Library**

Contains the reusable Blazor Navigation Menu components. This is a Razor Class Library that can be shared across different projects.

**2. BlazorNavigation.SampleApp**

A Blazor WebAssembly application that demonstrates how to use the Blazor Navigation Menu component. Contains example pages with different usage scenarios. 

Blazor WebAssembly was chosen for this project instead of other Blazor hosting models. Because the menu is purely a fronted component. It is more efficient to run it directly in the browser without relying on server-side rendering.

## BlazorNavigation.Library  ##

Here are the main files included in the project:

**1. Menu.razor**

The `Menu.razor` component serves as the root container for the navigation menu. It provides a structured way to define a multilevel nested navigation menu.

##### Usage  
	<Menu>
	    <MenuItems>
	        <MenuItem Text="Home" Href="/" />
	        <MenuItem Text="About" Href="/about" />
	    </MenuItems>
	</Menu>

##### Notes
The `Menu.razor` is implemented using `ChildContent` as a parameter of type `RenderFragment`. This allows us to pass another Blazor components inside the Menu, which is needed to achieve the nested structure. 

Also the component uses the `CascadingValue` `MenuLevel` to pass it to its child components, starting with the value 0. It is currently used to apply different styles on the menus, depending on their level. For instance in the `MenuItems.razor`, we set the class of the `ul`, depending on the level:

	private string GetMenuItemClass()
	{
		if (Level == 0)
			return "flex-row";
		
		return "flex-column dropdown-submenu";
	}

**2. MenuItems.razor**

The `MenuItems.razor` component acts as a wrapper for multiple MenuItem components and also supports nested structure.

##### Usage  
	<MenuItems>
    	<MenuItem Text="Item 1" />
    	<MenuItem Text="Item 2">
        	<MenuItems>
            	<MenuItem Text="Item 2.1" />
            	<MenuItem Text="Item 2.2" />
        	</MenuItems>
    	</MenuItem>
	</MenuItems>

##### Notes

This line of code `[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes { get; set; }` is used to enable passing extra HTML attributes (`id`, `class`, etc.) without modifying the component. Currently it is used to apply bootstrap classes.

**3. MenuItem.razor**

The `MenuItem.razor` component represents a single navigation item. It can optionally contain nested MenuItems to create a dropdown menu.

##### Usage  
	<MenuItem Text="Products" Href="/products">
    	<MenuItems>
        	<MenuItem Text="Category 1" Href="/products/category1" />
        	<MenuItem Text="Category 2" Href="/products/category2" />
    	</MenuItems>
	</MenuItem>

##### Notes

The flag `IsOpen` is used to toggle the menu visibility with the bootstrap class `dropdown-menu show`. It is set to `true` on mouse hover and to `false` on mouse leave or click.
