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

export const TagsToDto = (tags) => {
    let tagVM = [];
    tags.map((item, index) => {
        tagVM.push(item.name);
    })
    return tagVM;
}

export const TagNamesToSuggestions = (tags) => {
    let suggest = [];
    tags.map((tag, index) => {
        suggest.push({
            id: index,
            name: tag
        })
    })
    return suggest;
}