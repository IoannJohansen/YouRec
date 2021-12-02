export const ViewModelToSuggest = (tagVM) => {
    let suggestions = [];
    tagVM.forEach(tag => {
        suggestions.push({
            id: tag.id,
            name: tag.value
        })
    });
    return suggestions;
}