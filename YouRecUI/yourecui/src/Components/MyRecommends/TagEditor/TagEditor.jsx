import React, { useCallback, useEffect, useRef, useState } from 'react';
import { ViewModelToSuggest } from '../../../Converters/TagConverter';
import ReactTags from 'react-tag-autocomplete';
import { getTagList } from '../../../Api/ApiTag';
import './TagStyles.css';

export default function TagEditor(props) {

    const reactTags = useRef()
    const [suggestions, setSuggestions] = useState([]);

    useEffect(() => {
        getTagList().then(data => {
            const suggestions = ViewModelToSuggest(data.tags)
            setSuggestions(suggestions)
        })
    }, [])

    const onDelete = useCallback((tagIndex) => {
        props.tagSetter(props.selectedtags.filter((_, i) => i !== tagIndex))
    }, [props.selectedtags])

    const onAddition = useCallback((newTag) => {
        props.tagSetter([...props.selectedtags, newTag])
    }, [props.selectedtags])

    return (
        <>
            <ReactTags
                ref={reactTags}
                tags={props.selectedtags}
                allowNew={true}
                suggestions={suggestions}
                onDelete={onDelete}
                onAddition={onAddition}
            />
        </>
    )


}