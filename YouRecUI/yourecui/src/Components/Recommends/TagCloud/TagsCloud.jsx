import { useEffect, useState } from 'react';
import { TagCloud } from 'react-tagcloud';
import { getTagList } from '../../../Api/ApiTag';
import './TagsCloud.css';

const options = {
    luminosity: 'light',
    hue: 'blue'
}

export default function TagsCloud() {

    const [tags, setTags] = useState([]);

    useEffect(() => {
        getTagList().then(data => {
            setTags(data.tags);
            
        })
    }, []);


    // TODO: ADD ONCLICK EVENT : REDIRECT TO SEARCH LIST WITH SELECTED TAG
    return (
        // <p bg="primary" className="text-center h3">Available tags</p>
        <div className="container">
            {
                tags.length > 0 ?
                    <TagCloud
                        className="TagCloud col-3"
                        minSize={15}
                        disableRandomColor={false}
                        maxSize={35}
                        colorOptions={options}
                        tags={tags}
                        onClick={tag => alert(`'${tag.value}' was selected!`)}
                    /> : <p className="h2 text-center text-muted">There is no tags added</p>
            }
        </div>
    );
}