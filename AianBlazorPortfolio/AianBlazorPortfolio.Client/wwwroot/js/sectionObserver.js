window.observeSection = (elementId, dotNetObjRef, methodName, threshold = 0.3) => {
    const element = document.getElementById(elementId);
    if (!element) return;

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                // Call the .NET method to open the section.
                dotNetObjRef.invokeMethodAsync(methodName);
                // Unobserve the element after triggering once.
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: threshold });

    observer.observe(element);
};
