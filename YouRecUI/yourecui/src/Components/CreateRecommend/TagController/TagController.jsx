import React, { useCallback, useEffect, useRef, useState } from 'react';
import ReactTags from 'react-tag-autocomplete';
import './TagStyles.css';

export default function TagController() {

    const [tags, setTags] = useState([])

    const [suggestions, setSuggestions] = useState([
        { id: 1, name: "Apples" },
        { id: 2, name: "Pears" },
        { id: 3, name: "Bananas" },
        { id: 4, name: "Mangos" },
        { id: 5, name: "Lemons" },
        { id: 6, name: "Apricots" },
        { id: 7, name: "Badabum" }
    ])

    //TODO: add api call to take popular tags

    const reactTags = useRef()

    const onDelete = useCallback((tagIndex) => {
        setTags(tags.filter((_, i) => i !== tagIndex))
    }, [tags])

    const onAddition = useCallback((newTag) => {
        setTags([...tags, newTag])
    }, [tags])

    return (
        <ReactTags
            ref={reactTags}
            tags={tags}
            allowNew
            suggestions={suggestions}
            onDelete={onDelete}
            onAddition={onAddition}
        />
    )


}