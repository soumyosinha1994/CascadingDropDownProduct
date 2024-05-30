
jQuery(document).ready(function () {
    $('#Category_Id').change(function () {
        var categoryId = $(this).val();
        $.getJSON('/Home/GetSubCategory', { Id: categoryId }, function (subCategory) {
            var subCategorySelect = $('#SubCategory');
            subCategorySelect.empty();
            subCategorySelect.append($('<option/>', {
                value: 0,
                text: 'Select Sub-Category'
            }));
            $.each(subCategory, function (index, subCat) {

                subCategorySelect.append($('<option/>', {
                    value: subCat.value,
                    text: subCat.text
                }));
            });
        });
    });
    $('#SubCategory').change(function () {
        var ProductId = $(this).val();
        $.getJSON('/Home/GetProduct', { Id: ProductId }, function (product) {
            var ProductSelect = $('#Product');
            ProductSelect.empty();

            ProductSelect.append($('<option/>', {
                value: 0,
                text: 'Select Product'
            }));
            $.each(product, function (index, prod) {

                ProductSelect.append($('<option/>', {
                    value: prod.value,
                    text: prod.text
                }));
            });
        });
    });
});
