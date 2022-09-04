using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using nodetest.Models;

namespace nodetest.Utils;

public static class ElementUtils
{
    public class BoundingClientRect
    {
        public Vector2 Center => new()
        {
            X = (int)((Left + Right) / 2),
            Y = (int)((Top + Bottom) / 2)
        };
        
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
    }

    private static Func<ElementReference, IJSRuntime> _getJsRuntime;
    static ElementUtils()
    {
        var elementReferenceExtensionsType = typeof(ElementReferenceExtensions);
        
        var getJsRuntimeMethodInfo =  elementReferenceExtensionsType.GetMethod("GetJSRuntime", BindingFlags.NonPublic | BindingFlags.Static);

        _getJsRuntime = Delegate.CreateDelegate(typeof(Func<ElementReference, IJSRuntime>), getJsRuntimeMethodInfo) as Func<ElementReference, IJSRuntime>;
    }
    public static async Task<string> GetNameAsync(this ElementReference reference)
    {
        var runtime = _getJsRuntime(reference);
        
        return await runtime.InvokeAsync<string>("ElementUtils.getName", reference);
    }
    
    public static async Task<BoundingClientRect> GetBoundingClientRect(this ElementReference reference)
    {
        var runtime = _getJsRuntime(reference);
        
        return await runtime.InvokeAsync<BoundingClientRect>("ElementUtils.getBoundingClientRect", reference);
    }
}