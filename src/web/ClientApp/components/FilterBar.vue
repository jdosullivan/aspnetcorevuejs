<template>
    <div class="container-fluid cd-main-content custom-container">
        <div class="row">
            <div class="col-md-2 left-feild">
                <form action="/" class="input-search">
                    <input type="text" required="" placeholder="Enter keyword">
                    <i class="fa fa-search"></i>
                    <input type="submit" value="">
                </form>
            </div>
            <div class="col-md-10 ">
                <div class="for-be-dropdowns">
                    <div class="be-drop-down">
                        <i class="icon-projects"></i>
                        <span class="be-dropdown-content"> Projects	</span>
                        <ul class="drop-down-list" style="display: none;">
                            <li class="filter" data-filter=".category-1"><a data-type="category-1">Projects</a></li>
                            <li class="filter" data-filter=".category-2"><a data-type="category-2">Work in Progress</a></li>
                            <li class="filter" data-filter=".category-3"><a data-type="category-3">People</a></li>
                        </ul>
                    </div>
                    <div class="be-drop-down">
                        <i class="icon-creative"></i>
                        <span class="be-dropdown-content">
                            All Creative Filds
                        </span>
                        <ul class="drop-down-list" style="display: none;">
                            <li class="filter" data-filter=".category-4"><a>Item - 1</a></li>
                            <li class="filter" data-filter=".category-5"><a>Item - 2</a></li>
                            <li class="filter" data-filter=".category-1"><a>Item - 3</a></li>
                        </ul>
                    </div>
                    <div class="be-drop-down">
                        <i class="icon-features"></i>
                        <span class="be-dropdown-content">
                            Features
                        </span>
                        <ul class="drop-down-list" style="display: none;">
                            <li class="filter" data-filter=".category-2"><a>Featured</a></li>
                            <li class="filter" data-filter=".category-3"><a>Most Appreciated</a></li>
                            <li class="filter" data-filter=".category-4"><a>Most Viewed</a></li>
                            <li class="filter" data-filter=".category-5"><a>Most Discussed</a></li>
                            <li class="filter" data-filter=".category-1"><a>Most Recent</a></li>
                        </ul>
                    </div>
                    <div class="be-drop-down">
                        <i class="icon-worldwide"></i>
                        <span class="be-dropdown-content">
                            Worldwide
                        </span>
                        <ul class="drop-down-list">
                            <li class="filter" data-filter=".category-2"><a>WorldWide</a></li>
                            <li class="filter" data-filter=".category-3"><a>United States</a></li>
                            <li class="filter" data-filter=".category-4"><a>Germany</a></li>
                            <li class="filter" data-filter=".category-5"><a>United Kingdom</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>