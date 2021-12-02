import React, { useCallback, useEffect, useRef, useState } from 'react';
import { ViewModelToSuggest } from '../../../Converters/TagConverter';
import ReactTags from 'react-tag-autocomplete';
import { getTagList } from '../../../Api/ApiTag';
import './TagStyles.css';

export default function TagController(props) {

    const reactTags = useRef()
    const [tags, setTags] = useState([])

    const [suggestions, setSuggestions] = useState([])

    useEffect(() => {
        getTagList().then(data => {
            const suggestions = ViewModelToSuggest(data.tags)
            setSuggestions(suggestions)
        })
    }, [])

    const onDelete = useCallback((tagIndex) => {
        setTags(tags.filter((_, i) => i !== tagIndex))
        props.tagSetter([...tags]);
    }, [tags])

    const onAddition = useCallback((newTag) => {
        setTags([...tags, newTag])
        props.tagSetter([...tags, newTag]);
    }, [tags])

    return (
        <>
            <ReactTags
                ref={reactTags}
                tags={tags}
                allowNew
                suggestions={suggestions}
                onDelete={onDelete}
                onAddition={onAddition}
            />
        </>
    )


}