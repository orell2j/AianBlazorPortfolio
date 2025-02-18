window.carousel = {
    currentIndex: 0,
    container: null,
    items: [],
    totalItems: 0,

    updateSlider: function () {
        // Get all testimonial cards
        this.items = Array.from(this.container.children);
        this.totalItems = this.items.length;

        // Remove all positioning classes
        this.items.forEach(item => {
            item.classList.remove("center", "left", "right", "hidden");
        });

        if (this.totalItems === 0) return;

        // Determine indices for center, left and right testimonials (with wrap-around)
        let centerIndex = this.currentIndex;
        let leftIndex = (centerIndex - 1 + this.totalItems) % this.totalItems;
        let rightIndex = (centerIndex + 1) % this.totalItems;

        // Set classes accordingly
        this.items[centerIndex].classList.add("center");
        this.items[leftIndex].classList.add("left");
        this.items[rightIndex].classList.add("right");

        // Hide any testimonials not in this set
        for (let i = 0; i < this.totalItems; i++) {
            if (i !== centerIndex && i !== leftIndex && i !== rightIndex) {
                this.items[i].classList.add("hidden");
            }
        }
    },

    next: function () {
        if (this.totalItems === 0) return;
        this.currentIndex = (this.currentIndex + 1) % this.totalItems;
        this.updateSlider();
    },

    prev: function () {
        if (this.totalItems === 0) return;
        this.currentIndex = (this.currentIndex - 1 + this.totalItems) % this.totalItems;
        this.updateSlider();
    },

    init: function () {
        this.container = document.getElementById("testimonialContainer");
        if (!this.container) return;
        this.items = Array.from(this.container.children);
        this.totalItems = this.items.length;
        // Start with the first testimonial centered.
        this.currentIndex = 0;
        this.updateSlider();
    }
};

window.initializeTestimonialCarousel = function () {
    window.carousel.init();
};

window.carouselNext = function () {
    window.carousel.next();
};

window.carouselPrev = function () {
    window.carousel.prev();
};
