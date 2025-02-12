window.carousel = {
    currentIndex: 0,
    container: null,
    totalItems: 0,
    cardWidth: 0,
    gap: 20,

    init: function () {
        this.container = document.getElementById("testimonialContainer");
        if (!this.container) return;

        let cards = Array.from(this.container.children);
        this.totalItems = cards.length;

        if (this.totalItems === 0) return;

        this.cardWidth = cards[0].offsetWidth + this.gap;

        // Clone first and last elements for smooth looping
        let firstClone = cards[0].cloneNode(true);
        let lastClone = cards[this.totalItems - 1].cloneNode(true);

        this.container.appendChild(firstClone);
        this.container.insertBefore(lastClone, this.container.firstChild);

        this.totalItems += 2; // Account for clones

        this.currentIndex = 1; // Start at first real element
        this.centerCurrent(false);
    },

    centerCurrent: function (animate = true) {
        if (!this.container) return;

        const scrollPosition = this.currentIndex * this.cardWidth;
        this.container.scrollTo({ left: scrollPosition, behavior: animate ? "smooth" : "auto" });
    },

    next: function () {
        if (!this.container) return;

        this.currentIndex++;
        this.centerCurrent();

        // If at cloned first, jump to real first
        if (this.currentIndex === this.totalItems - 1) {
            setTimeout(() => {
                this.currentIndex = 1;
                this.centerCurrent(false);
            }, 500);
        }
    },

    prev: function () {
        if (!this.container) return;

        this.currentIndex--;
        this.centerCurrent();

        // If at cloned last, jump to real last
        if (this.currentIndex === 0) {
            setTimeout(() => {
                this.currentIndex = this.totalItems - 2;
                this.centerCurrent(false);
            }, 500);
        }
    }
};

// Initialize when page loads
window.initializeTestimonialCarousel = function () {
    window.carousel.init();
};

// Functions for buttons
window.carouselNext = function () {
    window.carousel.next();
};

window.carouselPrev = function () {
    window.carousel.prev();
};
